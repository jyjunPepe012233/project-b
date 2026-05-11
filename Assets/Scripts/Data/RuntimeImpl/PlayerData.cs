using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Runtime.Summon;
using UnityEngine;

namespace ProjectB.Data.RuntimeImpl
{
	// TODO: SerializeField 없이 자동 프로퍼티로만 구성하는 방법 고민해보기

	[Serializable]
	public class PlayerData : IPlayerData
	{
		[SerializeField] private int _level;
		public int Level => _level;
		
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

		[SerializeField] private List<IPlayerSoldier> _soldiers = new List<IPlayerSoldier>();
		public IReadOnlyCollection<IPlayerSoldier> Soldiers => _soldiers;
		
		[SerializeField] private List<IPlayerItem> _items = new List<IPlayerItem>();
		public IReadOnlyCollection<IPlayerItem> Items => _items;
		public event Action LevelChanged;
		public event Action CoinsChanged;
		public event Action GemsChanged;
		public event Action MoraleChanged;
		public event Action DailyMoraleRechargeCountChanged;
		public event Action FoodsChanged;

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


		void AddIntValueInternal(ref int field, int amount, Action changedEvent)
		{
			// 값이 최대 수치를 넘어서는 문제는 대부분의 로직에서 고려되지 않는 문제이므로
			// 예외적으로 데이터 구현체 내부에서 예외처리하여 에러를 방지함
			if (Int32.MaxValue - field < amount)
			{
				Debug.LogError("값이 최대 수치를 넘어섰습니다!");
				field = Int32.MaxValue;
				changedEvent?.Invoke();
				return;
			}
			
			field += amount;
			changedEvent?.Invoke();
		}
		
		bool TryConsumeIntValueInternal(ref int field, int amount, Action changedEvent)
		{
			if (field < amount)
			{
				return false;
			}

			field -= amount;
			changedEvent?.Invoke();
			return true;
		}

		public void AddLevel(int amount)
		{
			AddIntValueInternal(ref _level, amount, LevelChanged);
		}

		public void AddCoins(int amount)
		{
			AddIntValueInternal(ref _coins, amount, CoinsChanged);
		}

		public bool TryConsumeCoins(int amount)
		{
			return TryConsumeIntValueInternal(ref _coins, amount, CoinsChanged);
		}

		public void AddGems(int amount)
		{
			AddIntValueInternal(ref _gems, amount, GemsChanged);
		}

		public bool TryConsumeGems(int amount)
		{
			return TryConsumeIntValueInternal(ref _gems, amount, GemsChanged);
		}

		public void AddMorale(int amount)
		{
			AddIntValueInternal(ref _morale, amount, MoraleChanged);
		}

		public bool TryConsumeMorale(int amount)
		{
			return TryConsumeIntValueInternal(ref _morale, amount, MoraleChanged);
		}

		public void AddDailyMoraleRechargeCount(int amount)
		{
			// 솔직히 일일 사기 충전 횟수가 Int32.MaxValue를 넘어설 일은 없을 것 같지만 일단은 예외처리 해놓는 걸로
			AddIntValueInternal(ref _dailyMoraleRechargeCount, amount, DailyMoraleRechargeCountChanged);
		}

		public void ClearDailyMoraleRechargeCount()
		{
			_dailyMoraleRechargeCount = 0;
			DailyMoraleRechargeCountChanged?.Invoke();
		}

		public void AddFoods(int amount)
		{
			AddIntValueInternal(ref _foods, amount, FoodsChanged);
		}

		public bool TryConsumeFoods(int amount)
		{
			return TryConsumeIntValueInternal(ref _foods, amount, FoodsChanged);
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