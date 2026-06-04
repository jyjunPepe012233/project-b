using System;
using System.Collections.Generic;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface IInternalInventoryService
	{
		void GiveItem(IItemData itemData, int quantity, ItemGainAction gainAction);
		
		void GiveItems(IEnumerable<ItemGain> itemGains, ItemGainAction gainAction);

		bool TryClearItem(IItemData itemData, int quantity);
	}

}