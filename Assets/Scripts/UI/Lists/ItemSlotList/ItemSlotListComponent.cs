using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.UI.Core;

namespace ProjectB.UI.Lists.ItemSlotList
{

	public class ItemSlotListComponent : UIComponent<ItemSlotListView>
	{
		public void UpdateItems(IEnumerable<(IItemData itemData, int quantity)> data)
		{
			view.UpdateItems(data);
		}

		public void UpdateItems(IEnumerable<IPlayerItem> data)
		{
			var tuple = data.Select(item => (item.ItemData, item.Quantity));
			view.UpdateItems(tuple);
		}
	}

}
