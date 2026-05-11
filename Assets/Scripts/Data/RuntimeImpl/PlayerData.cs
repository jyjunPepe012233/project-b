using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Data.RuntimeImpl
{

	[Serializable]
	public class PlayerData : IPlayerData
	{
		[SerializeField] private int _coins;
		public int Coins => _coins;

		[SerializeField] private int _gems;
		public int Gems => _gems;

		[SerializeField] private int _morale;
		public int Morale => _morale;
		
		[SerializeField] private int _dailyMoraleRechargeCount;
		public int DailyMoraleRechargeCount => _dailyMoraleRechargeCount;

		[SerializeField] private int _foods;
		public int Foods => _foods;

		[SerializeField] private SoldierEquipments _equipments;
		public SoldierEquipments Equipments => _equipments;

		[SerializeField] private List<IPlayerSoldier> _soldiers = new List<IPlayerSoldier>();
		public IReadOnlyCollection<IPlayerSoldier> Soldiers => _soldiers;
		
		[SerializeField] private List<IPlayerItem> _items = new List<IPlayerItem>();
		public IReadOnlyCollection<IPlayerItem> Items => _items;
		
		public event Action CoinsChanged;
		public event Action GemsChanged;
		public event Action MoraleChanged;
		public event Action DailyMoraleRechargeCountChanged;
		public event Action FoodsChanged;
		public event Action EquipmentsChanged;

		public PlayerData()
		{
		}

		public PlayerData(int coins, int gems, int morale, int foods)
		{
			_coins = coins;
			_gems = gems;
			_morale = morale;
			_foods = foods;
		}


		public void AddCoins(int amount)
		{
			// 코인이 최대 수치(21억..)를 넘어서는 문제는
			// 대부분의 로직에서 고려되지 않으므로 PlayerData 내부에서 예외처리함.
			if (Int32.MaxValue - _coins < amount)
			{
				// 기능 작동에는 문제가 없도록 LogError 출력만 함
				Debug.LogError("코인이 최대 수치를 넘어섰습니다!");
				_coins = Int32.MaxValue;
				CoinsChanged?.Invoke();
				return;
			}

			_coins += amount;
			CoinsChanged?.Invoke();
		}

		public bool TryConsumeCoins(int amount)
		{
			if (_coins < amount)
			{
				return false;
			}

			_coins -= amount;
			CoinsChanged?.Invoke();
			return true;
		}

		public void AddGems(int amount)
		{
			// 보석이 최대 수치(21억..)를 넘어서는 문제는
			// 대부분의 로직에서 고려되지 않으므로 PlayerData 내부에서 예외처리함.
			if (Int32.MaxValue - _gems < amount)
			{
				// 기능 작동에는 문제가 없도록 LogError 출력만 함
				Debug.LogError("보석이 최대 수치를 넘어섰습니다!");
				_gems = Int32.MaxValue;
				GemsChanged?.Invoke();
				return;
			}

			_gems += amount;
			GemsChanged?.Invoke();
		}

		public bool TryConsumeGems(int amount)
		{
			if (_gems < amount)
			{
				return false;
			}

			_gems -= amount;
			GemsChanged?.Invoke();
			return true;
		}

		public void AddMorale(int amount)
		{
			if (Int32.MaxValue - _morale < amount)
			{
				// 기능 작동에는 문제가 없도록 LogError 출력만 함
				Debug.LogError("사기가 최대 수치를 넘어섰습니다!");
				_morale = Int32.MaxValue;
				MoraleChanged?.Invoke();
				return;
			}

			_morale += amount;
			MoraleChanged?.Invoke();
		}

		public bool TryConsumeMorale(int amount)
		{
			if (_morale < amount)
			{
				return false;
			}

			_morale -= amount;
			MoraleChanged?.Invoke();
			return true;
		}

		public void AddDailyMoraleRechargeCount(int amount)
		{
			// 일일 사기 충전 횟수가 Int 최대 수치를 넘어서는 일은
			// 솔직히 없을 것 같긴 하지만, 그래도 오류 나면 안되니까 예외처리.
			if (Int32.MaxValue - _dailyMoraleRechargeCount < amount)
			{
				Debug.LogError("일일 사기 충전 횟수가 최대 수치를 넘어섰습니다!");
				_dailyMoraleRechargeCount = Int32.MaxValue;
				DailyMoraleRechargeCountChanged?.Invoke();
				return;
			}

			_dailyMoraleRechargeCount += amount;
			DailyMoraleRechargeCountChanged?.Invoke();
		}

		public void ClearDailyMoraleRechargeCount()
		{
			_dailyMoraleRechargeCount = 0;
			DailyMoraleRechargeCountChanged?.Invoke();
		}

		public void AddFoods(int amount)
		{
			if (Int32.MaxValue - _foods < amount)
			{
				Debug.LogError("식량이 최대 수치를 넘어섰습니다!");
				_foods = Int32.MaxValue;
				FoodsChanged?.Invoke();
				return;
			}

			_foods += amount;
			FoodsChanged?.Invoke();
		}

		public bool TryConsumeFoods(int amount)
		{
			if (_foods < amount)
			{
				return false;
			}

			_foods -= amount;
			FoodsChanged?.Invoke();
			return true;
		}

		public void SetEquipment(SoldierEquipmentSlot slot, IEquipmentItem equipment)
		{
			switch (slot)
			{
				case SoldierEquipmentSlot.Slot1: _equipments.slot1 = equipment; break;
				case SoldierEquipmentSlot.Slot2: _equipments.slot2 = equipment; break;
				case SoldierEquipmentSlot.Slot3: _equipments.slot3 = equipment; break;
				case SoldierEquipmentSlot.Slot4: _equipments.slot4 = equipment; break;
				case SoldierEquipmentSlot.Slot5: _equipments.slot5 = equipment; break;
				case SoldierEquipmentSlot.Slot6: _equipments.slot6 = equipment; break;
			}
			EquipmentsChanged?.Invoke();
		}

		public void ClearEquipment(SoldierEquipmentSlot slot)
		{
			switch (slot)
			{
				case SoldierEquipmentSlot.Slot1: _equipments.slot1 = null; break;
				case SoldierEquipmentSlot.Slot2: _equipments.slot2 = null; break;
				case SoldierEquipmentSlot.Slot3: _equipments.slot3 = null; break;
				case SoldierEquipmentSlot.Slot4: _equipments.slot4 = null; break;
				case SoldierEquipmentSlot.Slot5: _equipments.slot5 = null; break;
				case SoldierEquipmentSlot.Slot6: _equipments.slot6 = null; break;
			}
			EquipmentsChanged?.Invoke();
		}

		public void AddSoldier(IPlayerSoldier soldier)
		{
			_soldiers.Add(soldier);
		}

		public void AddSoldiers(IEnumerable<IPlayerSoldier> soldiers)
		{
			_soldiers.AddRange(soldiers);
		}
		
		public void AddItem(IPlayerItem item)
		{
			_items.Add(item);
		}

		public void RemoveItem(IPlayerItem item)
		{
			_items.Remove(item);
		}

		public void AddItems(IEnumerable<IPlayerItem> items)
		{
			_items.AddRange(items);
		}
	}

}