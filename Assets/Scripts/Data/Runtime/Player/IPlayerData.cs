using System.Collections.Generic;
using ProjectB.Data.Runtime.Summon;

namespace ProjectB.Data.Runtime.Player
{

	public interface IPlayerData : IReadOnlyPlayerData
	{
		// 부모 인터페이스인 IReadOnlyPlayerData의 Soldiers 프로퍼티는 IReadOnlyCollection<IReadOnlyPlayerSoldier> 타입이지만,
		// IReadOnlyCollection은 공변성이 허용됨을 이용하여 IReadOnlyCollection<IPlayerSoldier>로 변환함.
		new IReadOnlyCollection<IPlayerSoldier> Soldiers { get; }
		
		new IReadOnlyCollection<IPlayerItem> Items { get; }
		
		void AddLevel(int amount);
		
		void AddExperience(int amount);
		
		void AddCoins(int amount);

		bool TryConsumeCoins(int amount);

		void AddGems(int amount);

		bool TryConsumeGems(int amount);

		void AddMorale(int amount);

		bool TryConsumeMorale(int amount);

		void AddDailyMoraleRechargeCount(int amount);

		void ClearDailyMoraleRechargeCount();

		void AddFoods(int amount);

		bool TryConsumeFoods(int amount);

		void AddSoldier(IPlayerSoldier soldier);

		void AddSoldiers(IEnumerable<IPlayerSoldier> soldiers);

		void AddItem(IPlayerItem item);

		void RemoveItem(IPlayerItem item);

		void AddItems(IEnumerable<IPlayerItem> items);
	}

}