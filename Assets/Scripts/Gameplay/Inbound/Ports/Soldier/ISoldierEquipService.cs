using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Inbound.Ports.Soldier
{

	public interface ISoldierEquipService
	{
		void Equip(IPlayerSoldier playerSoldier, SoldierEquipmentSlot slot, IEquipmentItem equipment);
	}

}