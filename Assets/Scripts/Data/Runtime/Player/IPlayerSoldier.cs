using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Data.Runtime.Player
{

	// TODO:
	// 수정할 의도가 없는데도 IReadOnlyPlayerSoldier가 아니라
	// IPlayerSoldier를 그대로 쓰는 곳 찾아서 바꾸기
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