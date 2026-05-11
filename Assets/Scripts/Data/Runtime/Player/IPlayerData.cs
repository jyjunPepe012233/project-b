using System.Collections.Generic;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Data.Runtime.Player
{

	public interface IPlayerData : IReadOnlyPlayerData
	{
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
		
		void SetEquipment(SoldierEquipmentSlot slot, IEquipmentItem equipment);
		
		void ClearEquipment(SoldierEquipmentSlot slot);
		
		void AddSoldier(IPlayerSoldier soldier);
		
		void AddSoldiers(IEnumerable<IPlayerSoldier> soldiers);
		
		void AddItem(IPlayerItem item);
		
		void RemoveItem(IPlayerItem item);
		
		void AddItems(IEnumerable<IPlayerItem> items);
	}

}