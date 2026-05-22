using System;
using System.Collections.Generic;
using AssetValidator;
using ProjectB.Data.Static.Item;
using ProjectB.UI.Core;
using ProjectB.UI.Parts;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Lists.ItemSlotList
{

	[Serializable]
	public class ItemSlotListView : UIView
	{
		[SerializeField] protected Transform contentParent;
		[SerializeField] protected ItemSlot slotPrefab;

		protected readonly List<ItemSlot> slotInstances = new();

		public virtual void UpdateItems(IEnumerable<(IItemData itemData, int quantity)> data)
		{
			foreach (var slot in slotInstances)
				Object.Destroy(slot.gameObject);
			slotInstances.Clear();

			foreach (var (itemData, quantity) in data)
			{
				var slot = Object.Instantiate(slotPrefab, contentParent);
				slot.SetItemInfo(itemData, quantity);
				slotInstances.Add(slot);
			}
		}

		public override ValidationMethod GetValidationMethod(ValidationMethod chain)
		{
			return base.GetValidationMethod(chain)
				.Register("ContentParent 할당", () => contentParent != null)
				.Register("SlotPrefab 할당", () => slotPrefab != null);
		}
	}

}
