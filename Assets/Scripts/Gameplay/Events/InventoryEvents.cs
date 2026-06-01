using System;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Events
{

	public class InventoryEvents
	{
		public Action<ItemGain, ItemGainAction> ItemAdded;
		
		public Action<ItemGain> ItemRemoved;
		
		public Action InventoryUpdated;
	}

}