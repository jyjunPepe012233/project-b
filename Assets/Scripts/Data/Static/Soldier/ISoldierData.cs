using ProjectB.Data.Static.Spirit;
using ProjectB.Data.Types;

namespace ProjectB.Data.Static.Soldier
{

	public interface ISoldierData
	{
		ISoldierCardDisplaySetting CardDisplaySetting { get; }
		
		ISoldierLevelUpSetting LevelUpSetting { get; }
		
		
		string SoldierId { get; }
		
		string SoldierName { get; }
		
		byte BornRank { get; } // 태생 성급 1,2,3
		
		ISpiritData Spirit { get; }
		
		ISoldierRoleData Role { get; }
		
		ISoldierAttackType AttackType { get; }
		
		ISoldierPosition Position { get; }
		
		SoldierStatus BaseStatus { get; }
		
		SoldierStatusf StatusGrowth { get; }
	}

}