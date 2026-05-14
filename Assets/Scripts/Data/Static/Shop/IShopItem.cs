using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Data.Static.Shop
{

	public interface IShopItem
	{
		CurrencyType CurrencyType { get; }
		
		int Price { get; }
		
		IItemData ItemData { get; }

		int Quantity { get; }
	}

}