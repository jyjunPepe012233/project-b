using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Internal.Computer;
using UnityEngine;

namespace ProjectB.Gameplay.Implements.Internal.Computer
{
	
	public class SoldierStatusComputer : ISoldierStatusComputer
	{
		public SoldierStatus ComputeSoldierStatus(ISoldierData soldierData, IPlayerSoldier playerSoldier)
		{
			return ComputeStatusAtLevel(soldierData, playerSoldier.Level);
		}

		public SoldierStatus GetNextLevelStatus(ISoldierData soldierData, IPlayerSoldier playerSoldier)
		{
			return ComputeStatusAtLevel(soldierData, playerSoldier.Level + 1);
		}

		
		// 나중에 레벨 외에도 장비, 버프 등 다른 요소들도 고려해서 스탯 계산하는 방식으로 확장해야 할 듯
		// 일단은 레벨에 따른 스텟 계산만 구현함
		
		private SoldierStatus ComputeStatusAtLevel(ISoldierData soldierData, int level)
		{
			// 레벨 당 BaseStatus에 StatusGrowth를 계속 곱하는 방식
			// (레벨이 오를수록 레벨 업을 통한 스탯 증가량이 커짐)
			
			var baseStatus = soldierData.BaseStatus;
			var growth = soldierData.StatusGrowth;

			var growthLevel = level - 1; // 레벨 1에는 성장 효과가 없다고 가정하는 처리 (레벨 2부터 곱함)
			var multiplier = new SoldierStatusf
			{
				hp = Mathf.Pow(1f + growth.hp, growthLevel),
				sp = Mathf.Pow(1f + growth.sp, growthLevel),
				physicalAttack = Mathf.Pow(1f + growth.physicalAttack, growthLevel),
				magicalAttack = Mathf.Pow(1f + growth.magicalAttack, growthLevel),
				physicalDefense = Mathf.Pow(1f + growth.physicalDefense, growthLevel),
				magicalDefense = Mathf.Pow(1f + growth.magicalDefense, growthLevel)
			};

			return baseStatus * multiplier;
		}
	}

}