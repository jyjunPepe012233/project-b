using System;
using System.Linq;
using ProjectB.Core.Supports;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.RuntimeImpl;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class InternalInventoryService : IInternalInventoryServicePort
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		private readonly ILoadRewardGainPopupPort _loadRewardGainPopupPort;

		public InternalInventoryService(IPlayerSessionHolderPort playerSessionHolderPort, ILoadRewardGainPopupPort loadRewardGainPopupPort)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
			_loadRewardGainPopupPort = loadRewardGainPopupPort;
		}

		public void GiveItem(IItemData itemData, int quantity, ItemGainAction gainAction)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			// 찾지 못하면 null이 할당됨
			var existingItem = playerData.Items.FirstOrDefault(x => x.ItemData == itemData);

			if (existingItem != null)
			{
				existingItem.AddQuantity(quantity);
			}
			else
			{
				IPlayerItem newItem = new PlayerItem(itemData, quantity);
				playerData.AddItem(newItem);
			}

			switch (gainAction)
			{
				case ItemGainAction.NoAction:
					Debug.Log("NoAction 아이템 획득: " + itemData.ItemId + " x" + quantity);
					break;
				
				case ItemGainAction.Reward:
					var singleItemGainArr = new[] { new ItemGain(itemData, quantity) };
					CoroutineHandler.StartAndAdd(_loadRewardGainPopupPort.Load(singleItemGainArr));
					break;
			}
			
		}
	}

}