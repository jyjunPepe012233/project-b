using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Static.Invasion;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound.Player;
using UnityEngine;

namespace ProjectB.Gameplay.Implements.Inbound
{

	public class SweepService : ISweepService
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		private readonly IInvasionSetting _invasionSetting;
		private readonly ISweepSetting _sweepSetting;
		private readonly IInternalPlayerLevelUpServicePort _internalPlayerLevelUpService;
		private readonly IInternalInventoryServicePort _internalInventoryService;

		public SweepService(IPlayerSessionHolderPort playerSessionHolderPort,
			IInvasionSetting invasionSetting,
			ISweepSetting sweepSetting,
			IInternalPlayerLevelUpServicePort internalPlayerLevelUpService,
			IInternalInventoryServicePort internalInventoryService)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
			_invasionSetting = invasionSetting;
			_sweepSetting = sweepSetting;
			_internalPlayerLevelUpService = internalPlayerLevelUpService;
			_internalInventoryService = internalInventoryService;
		}

		public void Sweep(IStageData targetStage, int count)
		{
			if (targetStage == null)
			{
				Debug.LogError("면제할 스테이지 데이터가 null임.");
				return;
			}
			
			if (count <= 0)
			{
				Debug.LogError("면제 횟수는 1 이상이어야 함. 전달된 값: " + count);
				return;
			}
			
			
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			// 면제 횟수에 따라 소모할 사기를 계산하고, 사기가 부족하면 면제 중단
			int totalMoraleCost = count * _sweepSetting.MoraleCost;
			if (!playerData.TryConsumeMorale(totalMoraleCost))
			{
				return;
			}

			// 경험치 보상
			int totalExperience = _invasionSetting.ExperienceReward * count;

			
			// 최종 획득 코인 개수가 저장됨.
			int totalCoins = targetStage.CoinReward * count;
			
			// noise 설정값이 0.1이면 보상은 CoinReward의 -10~10%으로 발생함 
			int noiseCoins = (int)(
				Random.Range(-_sweepSetting.CoinRewardNoise, _sweepSetting.CoinRewardNoise)
				* targetStage.CoinReward 
				* count);
			totalCoins += noiseCoins;
			
			
			// 최종 획득 아이템들과 그 수량들이 저장됨.
			// GiveItems()를 통해 한번에 아이템 획득을 반영하기 위함임
			var itemGains = new Dictionary<IItemData, int>();

			// 사실 ItemRewardProbability와 count를 곱하는 방식으로 아이템 보상 개수를 반복문 없이 계산할 수 있지만
			// UI의 면제 진행 연출을 위해 IEnumerable에 아이템 획득 정보를 나열할 필요가 있음.
			// (예: 면제 횟수가 촤라락 올라가며 면제를 통해 얻은 보상들도 실제 면제 현황에 따라 나열되는 애니메이션)
			// 따라서 아이템 획득 정보를 열거할 수 있도록 반복문을 사용했음 
			
			// 면제 횟수만큼 반복
			for (int i = 0; i < count; i++)
			{
				// 각 아이템 보상마다 확률 체크
				foreach (var itemGain in targetStage.ItemRewards)
				{
					if (Random.value < _sweepSetting.ItemRewardProbability)
					{
						// 아이템 획득 로직
						// Dictionary에 이미 존재하면 수량 누적, 없으면 새로 추가
						if (itemGains.ContainsKey(itemGain.item))
							itemGains[itemGain.item] += itemGain.quantity;
						else
							itemGains[itemGain.item] = itemGain.quantity;
					}
				}
			}

			// 경험치 보상 반영
			_internalPlayerLevelUpService.GiveExperience(totalExperience);
			
			// 코인 보상 반영
			playerData.AddCoins(totalCoins);

			// itemGains 딕셔너리에 모아둔 보상들을 GiveItems를 통해 한번에 반영시킴
			_internalInventoryService.GiveItems(
				itemGains.Select(kvp => new ItemGain(kvp.Key, kvp.Value)), ItemGainAction.Reward
			);
		}
	}

}
