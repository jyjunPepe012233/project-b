using System;
using System.Collections.Generic;
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
			
			// TODO: 플레이어 데이터 직렬화(JSON 저장 등) 로직 필요

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

		public void GiveItems(IEnumerable<ItemGain> itemGains, ItemGainAction gainAction)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			// ItemGains의 중복되는 아이템 항목을 없애는 처리
			Dictionary<IItemData, int> distinctItemGain = new();
			foreach (var itemGain in itemGains)
			{
				// 딕셔너리에 아이템이 없으면 추가, 있으면 개수 누적
				if (!distinctItemGain.TryAdd(itemGain.item, itemGain.quantity))
				{
					distinctItemGain[itemGain.item] += itemGain.quantity;
				}
			}

			foreach (var itemGain in distinctItemGain)
			{
				// 찾지 못하면 null이 할당됨
				var existingItem = playerData.Items.FirstOrDefault(x => x.ItemData == itemGain.Key);

				if (existingItem != null)
				{
					existingItem.AddQuantity(itemGain.Value);
				}
				else
				{
					IPlayerItem newItem = new PlayerItem(itemGain.Key, itemGain.Value);
					playerData.AddItem(newItem);
				}
			}
			
			// TODO: 플레이어 데이터 직렬화(JSON 저장 등) 로직 필요

			switch (gainAction)
			{
				case ItemGainAction.NoAction:
					Debug.Log("NoAction 아이템 획득! (벌크 획득 함수 사용)");
					break;
				
				case ItemGainAction.Reward:
					var itemGainArr = distinctItemGain.Select(kvp => new ItemGain(kvp.Key, kvp.Value));
					CoroutineHandler.StartAndAdd(_loadRewardGainPopupPort.Load(itemGainArr));
					break;
			}
		}

		public void ConsumeItem(IItemData itemData, int quantity)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			// 찾지 못하면 null이 할당됨
			var existingItem = playerData.Items.FirstOrDefault(x => x.ItemData == itemData);

			if (existingItem == null)
			{
				Debug.LogError($"존재하지 않은 아이템({itemData.ItemId})을 소모하려고 시도했음!");
				return;
			}

			if (!existingItem.TryRemoveQuantity(quantity))
			{
				Debug.LogError($"아이템({itemData.ItemId})을 소모할 수 없습니다!");
				return;
			}
			
			// 아이템 개수가 0이면 인벤토리에서 제거
			if (existingItem.Quantity == 0)
			{
				playerData.RemoveItem(existingItem);
			}
			
			// TODO: 플레이어 데이터 직렬화(JSON 저장 등) 로직 필요
		}
	}

}