using System;
using System.Collections.Generic;
using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.UI.Core;
using ProjectB.UI.Lists.ItemSlotList;
using UnityEngine;

namespace ProjectB.UI.Screens.BackpackScreen
{

	[Serializable]
	public class BackpackScreenView : UIView
	{
		[Required, SerializeField] private ItemSlotButtonListPresenter _itemList;
		[SerializeField] private ItemInfoPanelView _itemInfoPanel;
		
		public event Action<IItemData> ItemListSlotClicked;
		public event Action ConsumeButtonClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_itemInfoPanel.RegisterUICallbacks();
			
			_itemList.SlotClicked += OnItemListSlotClicked;
			_itemInfoPanel.ConsumeButtonClicked += OnConsumeButtonClicked;
		}
		
		public override void Dispose()
		{
			base.Dispose();
			_itemInfoPanel.Dispose();
			
			_itemList.SlotClicked -= OnItemListSlotClicked;
			_itemInfoPanel.ConsumeButtonClicked -= OnConsumeButtonClicked;
		}
		
		// 이제부터 protected virtual로 선언하는 습관을 들이기로 했음 (26.05.21.)
		protected virtual void OnItemListSlotClicked(IItemData itemData)
		{
			ItemListSlotClicked?.Invoke(itemData);
		}
		
		protected virtual void OnConsumeButtonClicked()
		{
			ConsumeButtonClicked?.Invoke();
		}
		
		
		public void UpdateItemList(IEnumerable<IReadOnlyPlayerItem> items)
		{
			_itemList.UpdateItems(items);
		}

		public void UpdateItemInfoPanel(IReadOnlyPlayerItem playerItem)
		{
			// TODO: 사실 이 코드는 View가 아니라 Presenter에 있어야 함 (데이터와 UI 사이의 연결을 담당하는 코드를 "의미"를 가지기 때문)
			
			_itemInfoPanel.SetItemNameText(playerItem.ItemData.ItemName);
			_itemInfoPanel.SetItemDescriptionText(playerItem.ItemData.DetailedDescription);
			_itemInfoPanel.SetItemQuantityText(playerItem.Quantity);
			_itemInfoPanel.SetConsumeButtonActive(playerItem.ItemData is IConsumableItem);
		}
		
		public void SetItemInfoPanelDisabledPanelActive(bool active)
		{
			_itemInfoPanel.SetDisabledPanelActive(active);
		}
		
		public void SetItemInfoPanelEnabledPanelActive(bool active)
		{
			_itemInfoPanel.SetEnabledPanelActive(active);
		}

		public override ValidationMethod GetValidationMethod(ValidationMethod chain)
		{
			var validationMethod = base.GetValidationMethod(chain)
				.Register("ItemList 할당", () => _itemList != null);
			return validationMethod;
		}
	}

}