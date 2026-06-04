using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.RuntimeImpl;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound.Player;
using UnityEngine;

namespace ProjectB.Gameplay.Implements.Internal
{

	public class InternalInventoryService : IInternalInventoryService
	{
		private readonly IHoldPlayerSessionPort _holdPlayerSessionPort;
		private readonly InventoryEvents _inventoryEvents;
		
		public InternalInventoryService(IHoldPlayerSessionPort holdPlayerSessionPort, InventoryEvents inventoryEvents)
		{
			_holdPlayerSessionPort = holdPlayerSessionPort;
			_inventoryEvents = inventoryEvents;
		}

		public void GiveItem(IItemData itemData, int quantity, ItemGainAction gainAction)
		{
			var playerData = _holdPlayerSessionPort.GetPlayerSession().PlayerData;

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

			_inventoryEvents.ItemAdded?.Invoke(
				new ItemGain[] { new(itemData, quantity) },
				gainAction
			);
			_inventoryEvents.InventoryUpdated?.Invoke();

			// TODO: 플레이어 데이터 직렬화(JSON 저장 등) 로직 필요
		}

		public void GiveItems(IEnumerable<ItemGain> itemGains, ItemGainAction gainAction)
		{
			var playerData = _holdPlayerSessionPort.GetPlayerSession().PlayerData;

			// ItemGains의 중복되는 아이템 항목을 없애는 처리
			Dictionary<IItemData, int> distinctItemGainDict = new();
			foreach (var itemGain in itemGains)
			{
				// 딕셔너리에 아이템이 없으면 추가, 있으면 개수 누적
				if (!distinctItemGainDict.TryAdd(itemGain.item, itemGain.quantity))
				{
					distinctItemGainDict[itemGain.item] += itemGain.quantity;
				}
			}

			foreach (var itemGain in distinctItemGainDict)
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


			// TODO: Non-Alloc 방식으로 변경 필요 (ListPool 등 활용)
			_inventoryEvents.ItemAdded?.Invoke(
				distinctItemGainDict.Select(kvp => new ItemGain(kvp.Key, kvp.Value)),
				gainAction
			);
			_inventoryEvents.InventoryUpdated?.Invoke();
			
			// TODO: 플레이어 데이터 직렬화(JSON 저장 등) 로직 필요
		}

		public bool TryClearItem(IItemData itemData, int quantity)
		{
			var playerData = _holdPlayerSessionPort.GetPlayerSession().PlayerData;

			// 찾지 못하면 null이 할당됨
			var existingItem = playerData.Items.FirstOrDefault(x => x.ItemData == itemData);

			if (existingItem == null)
			{
				Debug.LogError($"존재하지 않은 아이템({itemData.ItemId})을 소모하려고 시도했음!");
				return false;
			}

			if (!existingItem.TryRemoveQuantity(quantity))
			{
				Debug.LogError($"아이템({itemData.ItemId})을 소모할 수 없습니다!");
				return false;
			}
			
			// 아이템 개수가 0이면 인벤토리에서 제거
			if (existingItem.Quantity == 0)
			{
				playerData.RemoveItem(existingItem);
			}
			
			_inventoryEvents.ItemRemoved?.Invoke(new ItemGain[] { new(itemData, quantity) });
			_inventoryEvents.InventoryUpdated?.Invoke();
			
			// TODO: 플레이어 데이터 직렬화(JSON 저장 등) 로직 필요
			
			return true;
		}
	}

}