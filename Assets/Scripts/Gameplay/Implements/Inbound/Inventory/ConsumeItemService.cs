using ProjectB.Data.Static.Item;
using ProjectB.Gameplay.Ports.Inbound.Inventory;
using ProjectB.Gameplay.Ports.Internal;
using UnityEngine;

namespace ProjectB.Gameplay.Implements.Inbound.Inventory
{

	public class ConsumeItemService : IConsumeItemService
	{
		private readonly IInternalInventoryService _internalInventoryService;
		private readonly IConsumableItemResolver<IGainCurrencyItem> _gainCurrencyItemResolver;

		public ConsumeItemService(IInternalInventoryService internalInventoryService,
			IConsumableItemResolver<IGainCurrencyItem> gainCurrencyItemResolver)
		{
			_internalInventoryService = internalInventoryService;
			_gainCurrencyItemResolver = gainCurrencyItemResolver;
		}

		public void ConsumeItem(IItemData itemData)
		{
			// 플레이어의 인벤토리에서 아이템 소모 시도
			if (!_internalInventoryService.TryClearItem(itemData, 1)) // 지금은 일단 1개 소모 메서드만 구현하고 있음.
			{
				Debug.LogError("ConsumeItem을 시도했지만 아이템이 충분하지 않음 ItemData: " + itemData);
				return;
			}

			switch (itemData)
			{
				case IGainCurrencyItem gainCurrencyItem:
					_gainCurrencyItemResolver.OnConsume(gainCurrencyItem, 1); 
					break;
				
				default:
					Debug.LogError("소비 아이템을 소비할 수 없음. 이 타입에 대한 분기문이 존재하지 않음 ItemData Type: " + itemData.GetType());
					break;
			}
		}
	}

}