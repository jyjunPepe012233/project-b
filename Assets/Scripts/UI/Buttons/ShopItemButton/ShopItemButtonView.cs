using System;
using ProjectB.Data.Static.Shop;
using ProjectB.UI.Core;
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
		[SerializeField] private TextMeshProUGUI _itemQuantityText;
		[SerializeField] private TextMeshProUGUI _priceText;
		[SerializeField] private Button _purchaseButton;
		[SerializeField] private Transform _backgroundParent128;

		public event Action PurchaseButtonClicked;
		
		private GameObject _backgroundInstance;

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
			_itemQuantityText.text = shopItem.Quantity.ToString();
			_priceText.text = shopItem.Price.ToString();
			SetBackground128(shopItem.ItemData.ItemTier.BackgroundPrefab128);
		}

		void SetBackground128(GameObject prefab)
		{
			if (_backgroundInstance != null)
			{
				Object.Destroy(_backgroundInstance);
			}
			
			_backgroundInstance = Object.Instantiate(prefab, _backgroundParent128);
		}
	}

}