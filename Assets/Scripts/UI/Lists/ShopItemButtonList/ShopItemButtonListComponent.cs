using System.Collections.Generic;
using ProjectB.Data.Static.ShopItem;
using ProjectB.UI.Core;

namespace ProjectB.UI.Lists.ShopItemButtonList
{

	public class ShopItemButtonListComponent : UIComponent<ShopItemButtonListView>
	{
		public void UpdateShopItemData(IEnumerable<IShopItem> shopItems)
		{
			view.UpdateShopItemButton(shopItems);
		}
	}

}