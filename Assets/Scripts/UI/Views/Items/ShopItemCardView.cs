using AssetValidator;
using ProjectB.Core.Supports;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Views.Items
{

	public class ShopItemCardView : ButtonView
	{
		[SerializeField] private TextMeshProUGUI _itemNameText;
		[SerializeField] private TextMeshProUGUI _priceText;
		[SerializeField] private ItemSlotView _itemSlotView;

		public void Initialize(string itemName,
			int quantity,
			int price,
			Sprite iconSprite,
			GameObject tierBackgroundPrefab)
		{
			SetItemName(itemName);
			SetQuantity(quantity);
			SetPrice(price);
			SetIcon(iconSprite);
			SetTierBackground(tierBackgroundPrefab);
		}
		
		public void SetItemName(string itemName)
		{
			if (_itemNameText != null)
			{
				_itemNameText.text = itemName;
			}
		}
		
		public void SetQuantity(int quantity)
		{
			if (_itemSlotView != null)
			{
				_itemSlotView.SetItemQuantity(quantity);
			}
		}
		
		public void SetPrice(int price)
		{
			if (_priceText != null)
			{
				_priceText.text = price.ToString();
			}
		}
		
		public void SetIcon(Sprite iconSprite)
		{
			if (_itemSlotView != null)
			{
				_itemSlotView.SetIcon(iconSprite);
			}
		}
		
		public void SetTierBackground(GameObject prefab)
		{
			if (_itemSlotView != null)
			{
				_itemSlotView.SetTierBackground(prefab);
			}
		}
		
		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("ItemNameText 할당", () => _itemNameText != null)
				.Register("PriceText 할당", () => _priceText != null)
				.Register("ItemSlotView 할당", () => _itemSlotView != null);
		}
	}

}