using System;
using ProjectB.Data.Types;

namespace ProjectB.Data.Runtime.Player
{

	public interface IReadOnlyPlayerSoldier
	{
		string SoldierId { get; }
		
		byte Rank { get; }
		
		int Exp { get; }
		
		short Level { get; } // TODO: 그냥 int로 바꾸기. 메모리 2byte 줄여봐야 의미 없음 (메서드 호환성 안 좋음)
		
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