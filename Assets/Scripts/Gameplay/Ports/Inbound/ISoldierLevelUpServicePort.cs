using System;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ISoldierLevelUpServicePort
	{
		void ConsumeFoods(ISoldierData soldier);


		int GetConsumeFoodAmount(ISoldierData soldier);
		SoldierStatus GetNextLevelStatus(ISoldierData soldier);
		int GetNextLevelCombatPower(ISoldierData soldier);
	}

}