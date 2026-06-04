using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Ports.Inbound.Inventory
{

	public interface ICraftEquipmentService
	{
		void Craft(IEquipmentItem equipment);
	}

}