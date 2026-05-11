using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ISoldierEquipServicePort
	{
		void Equip(IPlayerSoldier playerSoldier, SoldierEquipmentSlot slot, IEquipmentItem equipment);
	}

}