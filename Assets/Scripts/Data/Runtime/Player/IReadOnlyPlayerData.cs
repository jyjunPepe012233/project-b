using System;
using System.Collections.Generic;
using ProjectB.Data.Types;

namespace ProjectB.Data.Runtime.Player
{

	public interface IReadOnlyPlayerData
	{
		int Level { get; }
		
		int Coins { get; }

		int Gems { get; }

		int Morale { get; }

		int DailyMoraleRechargeCount { get; }

		int Foods { get; }

		IReadOnlyCollection<IPlayerSoldier> Soldiers { get; }

		IReadOnlyCollection<IPlayerItem> Items { get; }
		
		event Action LevelChanged;

		event Action CoinsChanged;

		event Action GemsChanged;

		event Action MoraleChanged;

		event Action DailyMoraleRechargeCountChanged;

		event Action FoodsChanged;
	}

}