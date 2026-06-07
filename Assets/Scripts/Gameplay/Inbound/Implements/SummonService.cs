using System;
using System.Collections;
using ProjectB.Core.Supports;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Static.Summon;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Inbound.Ports;
using ProjectB.Gameplay.Internal.Ports.Factory;
using ProjectB.Gameplay.Internal.Ports.Overlay;
using ProjectB.Gameplay.Outbound.Ports.Player;
using UnityEngine;

namespace ProjectB.Gameplay.Inbound.Implements
{

	public class SummonService : ISummonService
	{
		private readonly ISoldierDatabase _soldierDatabase;
		private readonly IHoldPlayerSessionPort _holdPlayerSessionPort;
		private readonly ISummonCostSetting _summonCostSetting;
		private readonly IPlayerSoldierFactoryPort _playerSoldierFactoryPort;
		private readonly IOverlayManager _overlayManager;
		private readonly ISummonResultOverlayController _summonResultOverlayController;
		private readonly ISummonAnimationOverlayController _summonAnimationOverlayController;
		private readonly SummonAnimationEvents _summonAnimationEvents;
		private readonly SummonResultEvents _summonResultEvents;
		
		private bool _isAnimationPlaying;
		
		public SummonService(ISoldierDatabase soldierDatabase,
			IHoldPlayerSessionPort holdPlayerSessionPort,
			ISummonCostSetting summonCostSetting,
			IPlayerSoldierFactoryPort playerSoldierFactoryPort,
			IOverlayManager overlayManager,
			ISummonResultOverlayController summonResultOverlayController,
			ISummonAnimationOverlayController summonAnimationOverlayController,
			SummonAnimationEvents summonAnimationEvents,
			SummonResultEvents summonResultEvents)
		{
			_soldierDatabase = soldierDatabase;
			_holdPlayerSessionPort = holdPlayerSessionPort;
			_summonCostSetting = summonCostSetting;
			_playerSoldierFactoryPort = playerSoldierFactoryPort;
			_overlayManager = overlayManager;
			_summonResultOverlayController = summonResultOverlayController;
			_summonAnimationOverlayController = summonAnimationOverlayController;
			_summonAnimationEvents = summonAnimationEvents;
			_summonResultEvents = summonResultEvents;
		}

		
		public void Summon(SummonType type)
		{
			if (_isAnimationPlaying)
			{
				// 이미 애니메이션이 재생 중인 경우, 모집을 방지
				Debug.LogWarning("SummonManager: 모집 연출이 재생 중이므로 모집이 거부됨");
				return;
			}
			
			if (type == SummonType.Summon1x)
			{
				Summon1x();
			}
			else if (type == SummonType.Summon10x)
			{
				Summon10x();
			}
		}
		
		void Summon1x()
		{
			// 보석 소모
			var playerData = _holdPlayerSessionPort.GetPlayerSession().PlayerData;
			if (!playerData.TryConsumeGems(_summonCostSetting.Price1x))
			{
				// 보석 소모에 실패할 경우(부족할 경우) 모집을 방지
				Debug.Log("SummonManager: 보석이 부족하여 모집에 실패했습니다");
				return;
			}
			
			// 단수 모집
			int i = UnityEngine.Random.Range(0, _soldierDatabase.Soldiers.Count);
			var soldier = _soldierDatabase.Soldiers[i];

			// 저장
			playerData.AddSoldier(_playerSoldierFactoryPort.Create(soldier));
			
			// TODO:
			// PlayerSession의 정보를 직렬화하여 저장하는 과정 필요함
			// 모집 결과는 중요한 데이터이기 때문임
			// 아래 10뽑도 마찬가지로 저장 과정 필요함
			
			LoadSummonAnimation(new SummonResult(new []{ soldier }, SummonType.Summon1x));
		}

		void Summon10x()
		{
			// 보석 소모
			var playerData = _holdPlayerSessionPort.GetPlayerSession().PlayerData;
			if (!playerData.TryConsumeGems(_summonCostSetting.Price10x))
			{
				// 보석 소모에 실패할 경우(부족할 경우) 모집을 방지
				Debug.Log("SummonManager: 보석이 부족하여 모집에 실패했습니다");
				return;
			}
			
			// 10뽑
			ISoldierData[] summonedSoldiers = new ISoldierData[10];
			for (int i = 0; i < 10; i++)
			{
				int random = UnityEngine.Random.Range(0, _soldierDatabase.Soldiers.Count);
				summonedSoldiers[i] = _soldierDatabase.Soldiers[random];
			}
			
			// 저장
			playerData.AddSoldiers(
				Array.ConvertAll(summonedSoldiers, s => _playerSoldierFactoryPort.Create(s))
			);

			LoadSummonAnimation(new SummonResult(summonedSoldiers, SummonType.Summon10x));
		}
		
		
		
		
		void LoadSummonAnimation(SummonResult result)
		{
			CoroutineHandler.StartAndAdd(SummonAnimationCoroutine(result));
		}

		IEnumerator SummonAnimationCoroutine(SummonResult result)
		{
			if (_isAnimationPlaying)
			{
				// 애니메이션이 재생 중인 경우 애니메이션 로드 방지
				// 이미 위 메서드들에서 체크하고 있지만 확장 시 체크를 누락할 수 있으므로 한번 더 체크
				Debug.LogError("SummonManager: 모집 연출이 이미 재생 중이지만 다시 재생하려고 시도했습니다.");
				yield break;
			}

			_isAnimationPlaying = true;

			if (_overlayManager.CurrentOverlay == _summonResultOverlayController)
			{
				// 결과 화면이 켜져있으면 닫음
				yield return _overlayManager.Close();
			}

			// 애니메이션 시작
			yield return _overlayManager.Open(_summonAnimationOverlayController);

			// 애니메이션 주체가 애니메이션이 끝났음을 알릴 때까지 대기
			bool isFinished = false;
			_summonAnimationEvents.AnimationFinished += () => isFinished = true;

			// Invoke 후 즉시 AnimationFinished 이벤트가 발생할 수 있으므로
			// AnimationFinished 이벤트 구독 후에 이 이벤트를 Invoke해야 함.
			_summonAnimationEvents.StartAnimation?.Invoke(result);

			yield return new WaitUntil(() => isFinished);

			// 애니메이션 정리
			if (_overlayManager.CurrentOverlay == _summonAnimationOverlayController)
			{
				yield return _overlayManager.Close(); // 애니메이션 Overlay 닫기
			}
			else
			{
				Debug.LogWarning("SummonManager: 애니메이션이 끝난 시점에 애니메이션이 켜져있지 않습니다.");
			}

			_isAnimationPlaying = false;

			yield return _overlayManager.Open(_summonResultOverlayController); // 결과 Overlay 열기
			_summonResultEvents.ShowSummonResult?.Invoke(result);
		}
	}

}