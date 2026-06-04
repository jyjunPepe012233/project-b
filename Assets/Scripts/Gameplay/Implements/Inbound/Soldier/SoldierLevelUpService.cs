using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Inbound.Soldier;
using ProjectB.Gameplay.Ports.Internal.Computer;
using ProjectB.Gameplay.Ports.Outbound.Player;
using UnityEngine;

namespace ProjectB.Gameplay.Implements.Inbound.Soldier
{

	public class SoldierLevelUpService : ISoldierLevelUpService
	{
		private readonly IGlobalSoldierLevelUpSetting _globalSoldierLevelUpSetting;
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		private readonly ISoldierStatusComputer _soldierStatusComputer;
		private readonly ISoldierCombatPowerComputer _soldierCombatPowerComputer;

		public SoldierLevelUpService(IGlobalSoldierLevelUpSetting globalSoldierLevelUpSetting,
			IPlayerSessionHolderPort playerSessionHolderPort,
			ISoldierStatusComputer soldierStatusComputer, 
			ISoldierCombatPowerComputer soldierCombatPowerComputer)
		{
			_globalSoldierLevelUpSetting = globalSoldierLevelUpSetting;
			_playerSessionHolderPort = playerSessionHolderPort;
			_soldierStatusComputer = soldierStatusComputer;
			_soldierCombatPowerComputer = soldierCombatPowerComputer;
		}



		public void ConsumeFoods(ISoldierData soldier)
		{
			IPlayerData playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;
			
			// 플레이어가 soldier를 가지고 있는지 확인
			IPlayerSoldier playerSoldier = playerData.Soldiers.FirstOrDefault(i => i.SoldierData == soldier);
			if (playerSoldier == null)
			{
				Debug.LogError("플레이어가 보유하지 않은 병사를 강화하려 시도했습니다 SoldierId: " + soldier.SoldierId);
				return;
			}
			
			// 병사의 레벨이 플레이어 레벨보다 높게 올라가지 못함
			if (playerSoldier.Level >= playerData.Level)
			{
				Debug.LogWarning("병사의 레벨이 플레이어 레벨보다 높게 올라가지 못함. SoldierId: " + soldier.SoldierId);
				return;
			}
			
			// targetExp는 이 레벨에서 레벨 업을 하기 위해 필요한 식량의 수를 의미함
			int targetExp = soldier.LevelUpSetting.GetLevelUpExpOfLevel(playerSoldier.Level);

			// consumeFood는 이번에 병사의 경험치로 변환할 식량의 수를 의미함 
			int consumeFood = (int)(targetExp * _globalSoldierLevelUpSetting.FoodConsumeRatio);
			
			if (!playerData.TryConsumeFoods(consumeFood)) // 내림
			{
				return;
			}

			if (targetExp <= playerSoldier.Exp + consumeFood) // 경험치가 targetExp를 넘기거나 같아지면
			{
				// 일단 첫 1회 레벨업 진행
				int remainExp = playerSoldier.Exp + consumeFood - targetExp;
				playerSoldier.SetLevel((short)(playerSoldier.Level + 1));

				int nextTargetExp;
				
				// 다음 레벨의 target exp보다 현재 remainExp가 더 많이 남았을 때
				while ((nextTargetExp = soldier.LevelUpSetting.GetLevelUpExpOfLevel(playerSoldier.Level)) <= remainExp)
				{ 
					if (playerSoldier.Level >= playerData.Level) // 레벨업 반복 도중에 플레이어 레벨보다 병사 레벨이 높아지는 것을 방지
					{
						// 이 반복문에서 탈출하면 아래 SetExp에서 '남아있는 변환할 경험치'(remainExp)를 그대로 부여함
						// TODO:
						//   이 부분에서, 한번에 너무 많은 Food를 소비하여 남아있는 변환할 경험치가 레벨업에 필요한 경험치보다 많아지면
						//   병사의 레벨업 경험치 바 상태가 2000/1000 이런식으로 이상하게 보일 수도 있음.
						//   왠만하면 FOODS_CONSUME_RATIO를 1보다 낮게 잡기 때문에 이런 상황이 발생하지는 않을 것 같긴 한데, 일단 비슷한 문제가 생기면 여기를 의심해봐야 함.
						break;
					}

					// 레벨업 반복
					remainExp -= nextTargetExp;
					playerSoldier.SetLevel((short)(playerSoldier.Level + 1));
				}

				playerSoldier.SetExp(remainExp);
			}
			else
			{
				playerSoldier.SetExp(playerSoldier.Exp + consumeFood);
			}
			
			var newStatus = _soldierStatusComputer.ComputeSoldierStatus(soldier, playerSoldier);
			playerSoldier.SetStatus(newStatus);
			
			var newCombatPower = _soldierCombatPowerComputer.ComputeCombatPower(soldier, newStatus);
			playerSoldier.SetCombatPower(newCombatPower);
		}

		
		
		public int GetConsumeFoodAmount(ISoldierData soldier)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			var playerSoldier = playerData.Soldiers.FirstOrDefault(s => s.SoldierData == soldier);
			if (playerSoldier == null)
			{
				Debug.LogError("플레이어가 보유하지 않은 병사를 강화하려 시도했습니다 SoldierId: " + soldier.SoldierId);
				return 0;
			}

			var targetExp = soldier.LevelUpSetting.GetLevelUpExpOfLevel(playerSoldier.Level);
			return (int)(targetExp * _globalSoldierLevelUpSetting.FoodConsumeRatio);
		}

		public SoldierStatus GetNextLevelStatus(ISoldierData soldier)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			var playerSoldier = playerData.Soldiers.FirstOrDefault(s => s.SoldierData == soldier);
			if (playerSoldier == null)
			{
				Debug.LogError("플레이어가 보유하지 않은 병사를 강화하려 시도했습니다 SoldierId: " + soldier.SoldierId);
				return default;
			}
			
			return _soldierStatusComputer.GetNextLevelStatus(soldier, playerSoldier);
		}

		public int GetNextLevelCombatPower(ISoldierData soldier)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			var playerSoldier = playerData.Soldiers.FirstOrDefault(s => s.SoldierData == soldier);
			if (playerSoldier == null)
			{
				Debug.LogError("플레이어가 보유하지 않은 병사를 강화하려 시도했습니다 SoldierId: " + soldier.SoldierId);
				return 0;
			}
			
			SoldierStatus nextLevelStatus = _soldierStatusComputer.GetNextLevelStatus(soldier, playerSoldier);
			return _soldierCombatPowerComputer.ComputeCombatPower(soldier, nextLevelStatus);
		}
	}

}