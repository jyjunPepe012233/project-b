using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Ports.Inbound.Inventory
{

	public interface ICraftEquipmentServicePort
	{
		void Craft(IEquipmentItem equipment);
	}

}