using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Internal.Computer
{

	public interface ISoldierStatusComputer
	{
		SoldierStatus ComputeSoldierStatus(ISoldierData soldierData, IPlayerSoldier playerSoldier);
		
		SoldierStatus GetNextLevelStatus(ISoldierData soldierData, IPlayerSoldier playerSoldier);
	}

}