using System;
using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class ConsumeItemService : IConsumeItemServicePort
	{
		private readonly IInternalInventoryServicePort _internalInventoryServicePort;
		private readonly IConsumableItemResolverPort<IGainCurrencyItem> _gainCurrencyItemResolverPort;

		public ConsumeItemService(IInternalInventoryServicePort internalInventoryServicePort,
			IConsumableItemResolverPort<IGainCurrencyItem> gainCurrencyItemResolverPort)
		{
			_internalInventoryServicePort = internalInventoryServicePort;
			_gainCurrencyItemResolverPort = gainCurrencyItemResolverPort;
		}

		public void ConsumeItem(IItemData itemData)
		{
			// 플레이어의 인벤토리에서 아이템 소모 시도
			if (!_internalInventoryServicePort.TryClearItem(itemData, 1)) // 지금은 일단 1개 소모 메서드만 구현하고 있음.
			{
				Debug.LogError("ConsumeItem을 시도했지만 아이템이 충분하지 않음 ItemData: " + itemData);
				return;
			}

			switch (itemData)
			{
				case IGainCurrencyItem gainCurrencyItem:
					_gainCurrencyItemResolverPort.OnConsume(gainCurrencyItem, 1); 
					break;
				
				default:
					Debug.LogError("소비 아이템을 소비할 수 없음. 이 타입에 대한 분기문이 존재하지 않음 ItemData Type: " + itemData.GetType());
					break;
			}
		}
	}

}