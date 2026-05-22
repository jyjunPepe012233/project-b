using System;
using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.UI.Core;

namespace ProjectB.UI.Lists.ItemSlotList
{

	public class ItemSlotButtonListPresenter : UIPresenter<ItemSlotButtonListView>
	{
		public event Action<IItemData> SlotClicked;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.SlotClicked += OnViewSlotClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.SlotClicked -= OnViewSlotClicked;
		}

		public void UpdateItems(IEnumerable<IPlayerItem> data)
		{
			var tuple = data.Select(item => (item.ItemData, item.Quantity)); 
			view.UpdateItems(tuple);
		}

		void OnViewSlotClicked(IItemData itemData)
		{
			SlotClicked?.Invoke(itemData);
		}
	}

}