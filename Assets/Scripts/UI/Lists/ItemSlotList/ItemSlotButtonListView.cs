using System;
using System.Collections.Generic;
using AssetValidator;
using ProjectB.Data.Static.Item;
using ProjectB.UI.Parts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Lists.ItemSlotList
{
	
	[Serializable]
	public class ItemSlotButtonListView : ItemSlotListView
	{
		public event Action<IItemData> SlotClicked;
		
		public override void UpdateItems(IEnumerable<(IItemData itemData, int quantity)> data)
		{
			if (slotPrefab is not ItemSlotButton)
			{
				Debug.LogError("SlotPrefab이 ItemSlotButton이 아닙니다.");
				return;
			}
			
			foreach (var slot in slotInstances)
				Object.Destroy(slot.gameObject);
			slotInstances.Clear();
			
			foreach (var (itemData, quantity) in data)
			{
				ItemSlotButton slot = Object.Instantiate(slotPrefab, contentParent) as ItemSlotButton;
				slot.SetItemInfo(itemData, quantity);
				slot.Clicked += () => InvokeSlotClicked(itemData); 
				slotInstances.Add(slot);
			}
		}
		
		void InvokeSlotClicked(IItemData itemData)
		{
			SlotClicked?.Invoke(itemData);
		}

		public override ValidationMethod GetValidationMethod(ValidationMethod chain)
		{
			return base.GetValidationMethod(chain)
				.Register("SlotPrefab이 ItemSlotButton이 아님", () => slotPrefab == null || slotPrefab is ItemSlotButton);
		}
	}

}