using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.UI.Core;
using ProjectB.UI.Lists.ItemSlotList;
using UnityEngine;

namespace ProjectB.UI.Screens.BackpackScreen
{
	
	[Serializable]
	public class BackpackPage : UIView
	{
		[SerializeField] private ItemSlotListComponent _itemSlotListComponent;
		
		public void UpdateItemSlots(IEnumerable<IPlayerItem> playerItems)
		{
			_itemSlotListComponent.UpdateItems(playerItems);
		}
	}

}
