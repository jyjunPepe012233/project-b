using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Inbound.Ports.Soldier
{

	public interface ISoldierLevelUpService
	{
		void ConsumeFoods(ISoldierData soldier);


		int GetConsumeFoodAmount(ISoldierData soldier);
		SoldierStatus GetNextLevelStatus(ISoldierData soldier);
		int GetNextLevelCombatPower(ISoldierData soldier);
	}

}