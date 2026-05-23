using System;
using System.Collections.Generic;

namespace ProjectB.Data.Runtime.Player
{

	// IReadOnlyPlayerData는 플레이어 데이터를 읽기만 할 수 있는 인터페이스임
	// 제공하는 리스트의 제네릭 타입도 IReadOnlyPlayerItem 등으로 읽기 전용 인터페이스로 구성되어 있음 (IReadOnlyPlayerData를 구현한 IPlayerData에서는 공변성을 통해 IPlayerItem 등으로 변환함)
	
	// 목적: PlayerDataServicePort는 IReadOnlyPlayerData만을 제공하기 때문에 UI 등의 어셈블리에서는 플레이어 데이터를 수정할 수 없게 됨 
	public interface IReadOnlyPlayerData
	{
		string PlayerName { get; }
		
		int Level { get; }
		
		int Experience { get; }
		
		int Coins { get; }

		int Gems { get; }

		int Morale { get; }

		int DailyMoraleRechargeCount { get; }

		int Foods { get; }

		IReadOnlyCollection<IReadOnlyPlayerSoldier> Soldiers { get; }

		IReadOnlyCollection<IReadOnlyPlayerItem> Items { get; }
		
		event Action ExperienceChanged;
		
		event Action LevelChanged;

		event Action CoinsChanged;

		event Action GemsChanged;

		event Action MoraleChanged;

		event Action DailyMoraleRechargeCountChanged;

		event Action FoodsChanged;
	}

}