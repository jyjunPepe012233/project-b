using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Internal.Ports.Computer
{

	public interface ISoldierCombatPowerComputer
	{ 
		int ComputeCombatPower(ISoldierData soldierData, SoldierStatus status);
	}
	
}