using ProjectB.Data.Static.Item;

namespace ProjectB.Data.Runtime.Player
{

	public interface IReadOnlyPlayerItem
	{
		IItemData ItemData { get; }
		
		int Quantity { get; }
	}

}