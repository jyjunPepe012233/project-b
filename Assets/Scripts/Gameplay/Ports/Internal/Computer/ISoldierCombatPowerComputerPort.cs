using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface ISoldierCombatPowerComputerPort
	{ 
		int ComputeCombatPower(ISoldierData soldierData, SoldierStatus status);
	}
	
}