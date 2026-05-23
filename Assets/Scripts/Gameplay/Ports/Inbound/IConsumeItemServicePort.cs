using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IConsumeItemServicePort
	{
		void ConsumeItem(IItemData itemData);
	}

}