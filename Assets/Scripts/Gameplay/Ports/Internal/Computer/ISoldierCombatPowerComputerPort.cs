using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Internal.Computer
{

	public interface ISoldierCombatPowerComputerPort
	{ 
		int ComputeCombatPower(ISoldierData soldierData, SoldierStatus status);
	}
	
}