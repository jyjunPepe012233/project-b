using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Inbound.Ports.Inventory
{

	public interface ICraftEquipmentService
	{
		void Craft(IEquipmentItem equipment);
	}

}