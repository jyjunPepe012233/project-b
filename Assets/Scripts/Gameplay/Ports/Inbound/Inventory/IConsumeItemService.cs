using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Ports.Inbound.Inventory
{

	public interface IConsumeItemService
	{
		void ConsumeItem(IItemData itemData);
	}

}