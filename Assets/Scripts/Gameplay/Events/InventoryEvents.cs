using System;
using System.Collections.Generic;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Events
{

	public class InventoryEvents
	{
		public Action<IEnumerable<ItemGain>, ItemGainAction> ItemAdded;
		
		public Action<IEnumerable<ItemGain>> ItemRemoved;
		
		public Action InventoryUpdated;
	}

}