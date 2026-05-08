using System.Collections.Generic;
using ProjectB.Data.Static.ShopItem;
using ProjectB.UI.Lists.ShopItemButtonList;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Screens.ShopScreen
{

	public class ShopPageView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _pageNameText;
		[SerializeField] private ShopItemButtonListComponent _shopItemButtonList;
		
		public void SetPageName(string pageName)
		{
			_pageNameText.text = pageName;
		}
		
		public void InitializeAllItems(IEnumerable<IShopItem> shopItems)
		{
			_shopItemButtonList.UpdateShopItemData(shopItems);
		}
	}

}