using System.Collections.Generic;
using ProjectB.Data.Static.Shop;
using ProjectB.UI.Core;

namespace ProjectB.UI.Lists.ShopItemButtonList
{

	public class ShopItemButtonListPresenter : UIPresenter<ShopItemButtonListView>
	{
		public void UpdateShopItemData(IEnumerable<IShopItem> shopItems)
		{
			view.UpdateShopItemButton(shopItems);
		}
	}

}