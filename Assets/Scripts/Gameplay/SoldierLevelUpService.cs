using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class SoldierLevelUpService : ISoldierLevelUpServicePort
	{
		// ConsumeFoods 한번에 소모할 식량의 양 비율. 기준은 사도의 레벨업에 필요한 식량의 양
		// TODO: SO 기반 Setting으로 분리하기
		private const float FOODS_CONSUME_RATIO = 0.3f;
		
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		private readonly ISoldierStatusComputerPort _soldierStatusComputerPort;
		private readonly ISoldierCombatPowerComputerPort _soldierCombatPowerComputerPort;

		public SoldierLevelUpService(IPlayerSessionHolderPort playerSessionHolderPort,
			ISoldierStatusComputerPort soldierStatusComputerPort, 
			ISoldierCombatPowerComputerPort soldierCombatPowerComputerPort)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
			_soldierStatusComputerPort = soldierStatusComputerPort;
			_soldierCombatPowerComputerPort = soldierCombatPowerComputerPort;
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
			int targetExp = soldier.LevelUpExpSetting.GetLevelUpExpOfLevel(playerSoldier.Level);

			// consumeFood는 이번에 병사의 경험치로 변환할 식량의 수를 의미함 
			int consumeFood = (int)(targetExp * FOODS_CONSUME_RATIO);
			
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
				while ((nextTargetExp = soldier.LevelUpExpSetting.GetLevelUpExpOfLevel(playerSoldier.Level)) <= remainExp)
				{ 
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
			
			var newStatus = _soldierStatusComputerPort.ComputeSoldierStatus(soldier, playerSoldier);
			playerSoldier.SetStatus(newStatus);
			
			var newCombatPower = _soldierCombatPowerComputerPort.ComputeCombatPower(soldier, newStatus);
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

			var targetExp = soldier.LevelUpExpSetting.GetLevelUpExpOfLevel(playerSoldier.Level);
			return (int)(targetExp * FOODS_CONSUME_RATIO);
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
			
			return _soldierStatusComputerPort.GetNextLevelStatus(soldier, playerSoldier);
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
			
			SoldierStatus nextLevelStatus = _soldierStatusComputerPort.GetNextLevelStatus(soldier, playerSoldier);
			return _soldierCombatPowerComputerPort.ComputeCombatPower(soldier, nextLevelStatus);
		}
	}

}