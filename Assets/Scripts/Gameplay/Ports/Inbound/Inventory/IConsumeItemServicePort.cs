using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Ports.Inbound.Inventory
{

	public interface IConsumeItemServicePort
	{
		void ConsumeItem(IItemData itemData);
	}

}