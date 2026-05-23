using System;
using System.Collections.Generic;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface IInternalInventoryServicePort
	{
		event Action InventoryUpdated;
		
		void GiveItem(IItemData itemData, int quantity, ItemGainAction gainAction);
		
		void GiveItems(IEnumerable<ItemGain> itemGains, ItemGainAction gainAction);

		// TODO: Consume 대신 Clear나 Remove같은 네이밍이 더 적절할 수 있음. Consume은 아이템의 효과까지 포함하는 느낌임
		// 단순 아이템 소모와 '사용'의 차이임.
		bool TryConsumeItem(IItemData itemData, int quantity);
	}

}