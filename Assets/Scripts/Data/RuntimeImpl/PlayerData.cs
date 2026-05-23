using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using UnityEngine;

namespace ProjectB.Data.RuntimeImpl
{

	[Serializable]
	public class PlayerData : IPlayerData
	{
		private string _playerName;
		public string PlayerName => _playerName;
		
		private int _level;
		public int Level => _level;
		
		private int _experience;
		public int Experience => _experience;

		private int _coins;
		public int Coins => _coins;

		private int _gems;
		public int Gems => _gems;

		private int _morale;
		public int Morale => _morale;
		
		private int _dailyMoraleRechargeCount;
		public int DailyMoraleRechargeCount => _dailyMoraleRechargeCount;

		private int _foods;
		public int Foods => _foods;

		
		private readonly List<IPlayerSoldier> _soldiers = new List<IPlayerSoldier>();
		IReadOnlyCollection<IReadOnlyPlayerSoldier> IReadOnlyPlayerData.Soldiers => _soldiers; // IReadOnlyPlayerData로 접근하면 이 프로퍼티
		IReadOnlyCollection<IPlayerSoldier> IPlayerData.Soldiers => _soldiers; // IPlayerData로 접근하면 이 프로퍼티
		
		
		private readonly List<IPlayerItem> _items = new List<IPlayerItem>();
		IReadOnlyCollection<IReadOnlyPlayerItem> IReadOnlyPlayerData.Items => _items;
		IReadOnlyCollection<IPlayerItem> IPlayerData.Items => _items;
		
		
		public event Action ExperienceChanged;
		public event Action LevelChanged;
		public event Action CoinsChanged;
		public event Action GemsChanged;
		public event Action MoraleChanged;
		public event Action DailyMoraleRechargeCountChanged;
		public event Action FoodsChanged;


		public PlayerData(string playerName, int level, int experience, int coins, int gems, int morale, int foods)
		{
			_playerName = playerName;
			_level = level;
			_experience = experience;
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

		public void AddExperience(int amount)
		{
			AddIntValueInternal(ref _experience, amount, ExperienceChanged);
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