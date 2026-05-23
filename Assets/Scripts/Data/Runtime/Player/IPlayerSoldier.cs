using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Data.Runtime.Player
{

	public interface IPlayerSoldier : IReadOnlyPlayerSoldier
	{
		void SetRank(byte rank);
		
		void SetExp(int exp);
		
		void SetLevel(short level);

		void SetStatus(SoldierStatus status);
		
		void SetEquipment(SoldierEquipmentSlot slot, IEquipmentItem equipment);

		void ClearEquipment(SoldierEquipmentSlot slot);
		
		void SetCombatPower(int combatPower);
	}

}