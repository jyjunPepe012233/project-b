using System;
using System.Collections.Generic;
using ProjectB.Data.Static.Item;
using ProjectB.UI.Components;
using ProjectB.UI.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Lists.ItemSlotList
{

	[Serializable]
	public class ItemSlotListView : UIView
	{
		[SerializeField] private Transform _contentParent;
		[SerializeField] private ItemSlot _slotPrefab;

		private readonly List<ItemSlot> _slotInstances = new();

		public void UpdateItems(IEnumerable<(IItemData itemData, int quantity)> data)
		{
			foreach (var slot in _slotInstances)
				Object.Destroy(slot.gameObject);
			_slotInstances.Clear();

			foreach (var (itemData, quantity) in data)
			{
				var slot = Object.Instantiate(_slotPrefab, _contentParent);
				slot.SetItemInfo(itemData, quantity);
				_slotInstances.Add(slot);
			}
		}
	}

}
