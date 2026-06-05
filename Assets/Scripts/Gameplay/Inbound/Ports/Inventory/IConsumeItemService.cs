using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Inbound.Ports.Inventory
{

	public interface IConsumeItemService
	{
		void ConsumeItem(IItemData itemData);
	}

}