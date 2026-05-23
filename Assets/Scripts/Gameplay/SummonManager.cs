using System;
using System.Collections;
using ProjectB.Core.Supports;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Static.Summon;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class SummonManager : ISummonServicePort, ISummonAnimationManagerPort
	{
		private readonly ISoldierDatabase _soldierDatabase;
		private readonly ILoadSummonAnimationScreenPort _loadSummonAnimationScreenPort;
		private readonly ILoadSummonResultScreenPort _loadSummonResultScreenPort;
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		private readonly ISummonCostSetting _summonCostSetting;
		private readonly IPlayerSoldierFactoryPort _playerSoldierFactoryPort;
		
		public event Action<SummonResult> StartAnimation;
		public event Action AnimationPerfectlyUnloaded;
		public event Action<SummonResult> ShowSummonResult;

		// 외부에서는 ISummonAnimationManagerPort.AnimationFinished() 메서드를 통해서 애니메이션 종료를 알리고
		// AnimationFinished() 메서드가 _AnimationFinishedInternal 이벤트를 호출하는 형태로 구현함.
		// (코루틴 중에 애니메이션 종료를 알아야 하기 때문임)
		private event Action _AnimationFinishedInternal;

		private bool _isAnimationPlaying;
		
		public SummonManager(ISoldierDatabase soldierDatabase,
			ILoadSummonAnimationScreenPort loadSummonAnimationScreenPort,
			ILoadSummonResultScreenPort loadSummonResultScreenPort, 
			IPlayerSessionHolderPort playerSessionHolderPort,
			ISummonCostSetting summonCostSetting,
			IPlayerSoldierFactoryPort playerSoldierFactoryPort)
		{
			_soldierDatabase = soldierDatabase;
			_loadSummonAnimationScreenPort = loadSummonAnimationScreenPort;
			_loadSummonResultScreenPort = loadSummonResultScreenPort;
			_playerSessionHolderPort = playerSessionHolderPort;
			_summonCostSetting = summonCostSetting;
			_playerSoldierFactoryPort = playerSoldierFactoryPort;
		}

		
		public void Summon(SummonType type)
		{
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
			if (_isAnimationPlaying)
			{
				// 이미 애니메이션이 재생 중인 경우, 모집을 방지
				return;
			}
			
			// 보석 소모
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;
			if (!playerData.TryConsumeGems(_summonCostSetting.Price1x))
			{
				// 보석 소모에 실패할 경우(부족할 경우) 모집을 방지
				Debug.Log("보석이 부족하여 모집에 실패했습니다");
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
			if (_isAnimationPlaying) return;
			
			// 보석 소모
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;
			if (!playerData.TryConsumeGems(_summonCostSetting.Price10x))
			{
				// 보석 소모에 실패할 경우(부족할 경우) 모집을 방지
				Debug.Log("보석이 부족하여 모집에 실패했습니다");
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
				Debug.LogError("모집 연출이 이미 재생 중이지만 다시 재생하려고 시도했습니다.");
				yield break;
			}

			if (_loadSummonResultScreenPort.IsLoaded)
			{
				// 결과 화면이 켜져있으면 닫음
				yield return _loadSummonResultScreenPort.UnloadSummonResultScreen();
			}
			
			_isAnimationPlaying = true;
			
			// 애니메이션 로드 및 시작 (뽑기 결과 전달)
			yield return _loadSummonAnimationScreenPort.LoadSummonAnimationScreen();
			StartAnimation?.Invoke(result);

			// 애니메이션 주체가 애니메이션이 끝났음을 알릴 때까지 대기
			bool isFinished = false;
			_AnimationFinishedInternal += () => isFinished = true;
			yield return new WaitUntil(() => isFinished);

			// 애니메이션 정리
			yield return _loadSummonAnimationScreenPort.UnloadSummonAnimationScreen();
			AnimationPerfectlyUnloaded?.Invoke();
			
			_isAnimationPlaying = false;
			
			yield return _loadSummonResultScreenPort.LoadSummonResultScreen(result);
			ShowSummonResult?.Invoke(result); // 결과 화면이 켜졌으면 화면에 결과 전달
		}
		
		// 외부의 애니메이션 연출 주체가 애니메이션이 끝났음을 알리는 메서드
		public void FinishAnimation()
		{
			_AnimationFinishedInternal?.Invoke();
		}
	}

}