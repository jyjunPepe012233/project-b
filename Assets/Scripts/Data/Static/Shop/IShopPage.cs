using System.Collections.Generic;

namespace ProjectB.Data.Static.Shop
{

	public interface IShopPage
	{
		string ShopPageId { get; }
		
		string ShopPageName { get; }
		
		IEnumerable<IShopItem> ShopItems { get; }
	}

}