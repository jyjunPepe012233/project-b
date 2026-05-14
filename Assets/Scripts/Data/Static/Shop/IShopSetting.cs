using System.Collections.Generic;

namespace ProjectB.Data.Static.Shop
{

	public interface IShopSetting
	{
		IReadOnlyList<IShopPage> ShopPages { get; }
	}

}