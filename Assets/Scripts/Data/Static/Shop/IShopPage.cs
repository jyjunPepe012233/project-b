using System.Collections.Generic;
using UnityEngine;

namespace ProjectB.Data.Static.Shop
{

	public interface IShopPage
	{
		string ShopPageId { get; }
		
		string ShopPageName { get; }
		
		Sprite Icon128 { get; }
		
		IEnumerable<IShopItem> ShopItems { get; }
	}

}