using ProjectB.Data.Static.Shop;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Buttons.ShopItemButton
{

	public class ShopItemButtonComponent : UIComponent<ShopItemButtonView>
	{
		private IShopItem _shopItemData;
		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.PurchaseButtonClicked += OnPurchaseButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.PurchaseButtonClicked -= OnPurchaseButtonClicked;
		}
		
		void OnPurchaseButtonClicked()
		{
			ShopItemButtonEvents.Clicked?.Invoke(_shopItemData);
		}

		public void InitializeShopItemData(IShopItem itemData)
		{ 
			_shopItemData = itemData;
			view.InitializeShopItemData(itemData);
		}
	}

}