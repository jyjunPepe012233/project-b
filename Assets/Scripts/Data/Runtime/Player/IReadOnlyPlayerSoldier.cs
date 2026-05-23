using System;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Data.Runtime.Player
{

	public interface IReadOnlyPlayerSoldier
	{
		ISoldierData SoldierData { get; }
		
		byte Rank { get; }
		
		int Exp { get; }
		
		int Level { get; } // Level은 21억까지 표현해야하는 숫자는 아니지만 연산이 많아 메서드/연산자 호환성을 위해 int로 선언함
		
		SoldierStatus Status { get; }
		
		SoldierEquipments Equipments { get; }
		
		int CombatPower { get; }
		
		event Action RankChanged;

		event Action ExpChanged;

		event Action LevelChanged;

		event Action StatusChanged;
		
		event Action EquipmentsChanged;
		
		event Action CombatPowerChanged;
	}

}