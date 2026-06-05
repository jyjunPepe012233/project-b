using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Internal.Ports.Factory
{

	public interface IPlayerSoldierFactoryPort
	{
		IPlayerSoldier Create(ISoldierData soldierData);
	}

}