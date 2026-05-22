using System;
using ProjectB.Data.Static.Shop;
using ProjectB.UI.Core;
using ProjectB.UI.Parts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Buttons.ShopItemButton
{

	[Serializable]
	public class ShopItemButtonView : UIView
	{
		[SerializeField] private TextMeshProUGUI _itemNameText;
		[SerializeField] private ItemSlot _itemVisual;
		[SerializeField] private TextMeshProUGUI _priceText;
		[SerializeField] private Button _purchaseButton;

		public event Action PurchaseButtonClicked;
		
		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_purchaseButton.onClick.AddListener(OnPurchaseButtonClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
			_purchaseButton.onClick.RemoveListener(OnPurchaseButtonClicked);
		}
		
		void OnPurchaseButtonClicked()
		{
			PurchaseButtonClicked?.Invoke();
		}
		
		public void InitializeShopItemData(IShopItem shopItem)
		{
			_itemNameText.text = shopItem.ItemData.ItemName;
			_itemVisual.SetItemInfo(shopItem.ItemData, shopItem.Quantity);
			_priceText.text = shopItem.Price.ToString();
		}
	}

}