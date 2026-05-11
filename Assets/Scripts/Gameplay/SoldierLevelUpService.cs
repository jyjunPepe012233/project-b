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
		private readonly ISoldierDatabase _soldierDatabase;
		private readonly ISoldierStatusComputerPort _soldierStatusComputerPort;
		private readonly ISoldierCombatPowerComputerPort _soldierCombatPowerComputerPort;

		public SoldierLevelUpService(IPlayerSessionHolderPort playerSessionHolderPort,
			ISoldierDatabase soldierDatabase,
			ISoldierStatusComputerPort soldierStatusComputerPort, 
			ISoldierCombatPowerComputerPort soldierCombatPowerComputerPort)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
			_soldierDatabase = soldierDatabase;
			_soldierStatusComputerPort = soldierStatusComputerPort;
			_soldierCombatPowerComputerPort = soldierCombatPowerComputerPort;
		}


		public void ConsumeFoods(string soldierId)
		{
			var soldierData = _soldierDatabase.GetSoldierById(soldierId);
			if (soldierData != null)
			{
				ConsumeFoods(soldierData);
			}
		}

		public void ConsumeFoods(ISoldierData soldier)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;
			
			// 플레이어가 soldier를 가지고 있는지 확인
			var playerSoldier = playerData.Soldiers.FirstOrDefault();
			if (playerSoldier == null)
			{
				Debug.LogError("플레이어가 보유하지 않은 병사를 강화하려 시도했습니다 SoldierId: " + playerSoldier.SoldierId);
				return;
			}
			
			// TODO: 플레이어의 레벨을 바탕으로 병사의 최대 레벨에 제한 두기  

			ISoldierData soldierData = _soldierDatabase.GetSoldierById(playerSoldier.SoldierId);
			
			// targetExp는 이 레벨에서 레벨 업을 하기 위해 필요한 식량의 수를 의미함
			int targetExp = soldierData.LevelUpExpSetting.GetLevelUpExpOfLevel(playerSoldier.Level);

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
				while ((nextTargetExp = soldierData.LevelUpExpSetting.GetLevelUpExpOfLevel(playerSoldier.Level)) <= remainExp)
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
			
			var newStatus = _soldierStatusComputerPort.ComputeSoldierStatus(soldierData, playerSoldier);
			playerSoldier.SetStatus(newStatus);
			
			var newCombatPower = _soldierCombatPowerComputerPort.ComputeCombatPower(soldierData, newStatus);
			playerSoldier.SetCombatPower(newCombatPower);
		}

		public void LevelUpTo(string soldierId, short targetLevel)
		{
			var soldierData = _soldierDatabase.GetSoldierById(soldierId);
			if (soldierData != null)
			{ 
				LevelUpTo(soldierData, targetLevel);
			}
		}

		public void LevelUpTo(ISoldierData soldier, short targetLevel)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			var playerSoldier = playerData.Soldiers.FirstOrDefault(s => s.SoldierId == soldier.SoldierId);
			if (playerSoldier == null)
			{
				Debug.LogError("플레이어가 보유하지 않은 병사를 강화하려 시도했습니다 SoldierId: " + soldier.SoldierId);
				return;
			}

			ISoldierData soldierData = _soldierDatabase.GetSoldierById(playerSoldier.SoldierId);

			while (playerSoldier.Level < targetLevel) // 목표 레벨이 될때까지 반복함
			{
				int targetExp = soldierData.LevelUpExpSetting.GetLevelUpExpOfLevel(playerSoldier.Level);
				int neededExp = targetExp - playerSoldier.Exp;

				if (playerData.Foods >= neededExp) // 식량이 이번 레벨을 올리기 충분하면
				{
					playerData.TryConsumeFoods(neededExp);
					playerSoldier.SetExp(0);
					playerSoldier.SetLevel((short)(playerSoldier.Level + 1));
				}
				else
				{
					// 식량이 충분하지 않으면
					// 모든 식량을 소모한 뒤 레벨업 진행을 멈춤
					int remainingFoods = playerData.Foods;
					playerData.TryConsumeFoods(remainingFoods);
					playerSoldier.SetExp(playerSoldier.Exp + remainingFoods);
					break;
				}
			}
			
			var newStatus = _soldierStatusComputerPort.ComputeSoldierStatus(soldierData, playerSoldier);
			playerSoldier.SetStatus(newStatus);
			
			var newCombatPower = _soldierCombatPowerComputerPort.ComputeCombatPower(soldierData, newStatus);
			playerSoldier.SetCombatPower(newCombatPower);
		}

		
		public int GetConsumeFoodAmount(string soldierId)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			var playerSoldier = playerData.Soldiers.FirstOrDefault(s => s.SoldierId == soldierId);
			if (playerSoldier == null)
			{
				Debug.LogError("플레이어가 보유하지 않은 병사를 강화하려 시도했습니다 SoldierId: " + soldierId);
				return 0;
			}

			ISoldierData soldierData = _soldierDatabase.GetSoldierById(playerSoldier.SoldierId);

			var targetExp = soldierData.LevelUpExpSetting.GetLevelUpExpOfLevel(playerSoldier.Level);
			return (int)(targetExp * FOODS_CONSUME_RATIO);
		}

		public SoldierStatus GetNextLevelStatus(string soldierId)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			var playerSoldier = playerData.Soldiers.FirstOrDefault(s => s.SoldierId == soldierId);
			if (playerSoldier == null)
			{
				Debug.LogError("플레이어가 보유하지 않은 병사를 강화하려 시도했습니다 SoldierId: " + soldierId);
				return default;
			}

			ISoldierData soldierData = _soldierDatabase.GetSoldierById(playerSoldier.SoldierId);
			return _soldierStatusComputerPort.GetNextLevelStatus(soldierData, playerSoldier);
		}

		public int GetNextLevelCombatPower(string soldierId)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			var playerSoldier = playerData.Soldiers.FirstOrDefault(s => s.SoldierId == soldierId);
			if (playerSoldier == null)
			{
				Debug.LogError("플레이어가 보유하지 않은 병사를 강화하려 시도했습니다 SoldierId: " + soldierId);
				return 0;
			}

			ISoldierData soldierData = _soldierDatabase.GetSoldierById(playerSoldier.SoldierId);
			SoldierStatus nextLevelStatus = _soldierStatusComputerPort.GetNextLevelStatus(soldierData, playerSoldier);
			return _soldierCombatPowerComputerPort.ComputeCombatPower(soldierData, nextLevelStatus);
		}
	}

}