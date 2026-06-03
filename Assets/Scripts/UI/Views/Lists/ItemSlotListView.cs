using ProjectB.UI.Collections;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Items;
using UnityEngine;

namespace ProjectB.UI.Views.Lists
{

	public class ItemSlotListView : UIView
	{
		[SerializeField] private Transform _content;
		
		private ComponentPrefabPool<ItemSlotView> _itemSlotPool;
		
		public void Initialize(ItemSlotView slotPrefab, int initialCapacity = 0)
		{
			_itemSlotPool = new ComponentPrefabPool<ItemSlotView>(_content, slotPrefab, initialCapacity);
		}

		public ItemSlotView CreateSlot()
		{
			return _itemSlotPool.Load();
		}

		public void ClearSlots()
		{
			_itemSlotPool.UnloadAll();
		}
	}

}
