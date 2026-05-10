using System;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using UnityEngine;

namespace ProjectB.Data.RuntimeImpl
{

	[Serializable]
	public class PlayerItem : IPlayerItem
	{
		[SerializeField] private IItemData _itemData;
		public IItemData ItemData => _itemData;
		
		[SerializeField] private int _quantity;
		public int Quantity => _quantity;

		public PlayerItem(IItemData itemData, int quantity)
		{
			_itemData = itemData;
			_quantity = quantity;
		}

		public void AddQuantity(int amount)
		{
			// 아이템이 int의 한도를 넘어가는 경우는 대부분의 게임 로직에서 고려하지 않는 예외적인 상황이므로
			// Data 계층에서 예외처리함
			if (Int32.MaxValue - _quantity < amount)
			{
				Debug.LogError("아이템 수량이 Int 최대치를 초과함");
				return;
			}
			
			_quantity += amount;
		}

		public bool TryRemoveQuantity(int amount)
		{
			if (_quantity < amount)
			{
				Debug.LogError("아이템 수량이 부족하여 제거할 수 없음");
				return false;
			}
			
			_quantity -= amount;
			return true;
		}
	}

}