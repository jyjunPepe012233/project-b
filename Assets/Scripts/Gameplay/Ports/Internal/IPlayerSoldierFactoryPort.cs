using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface IPlayerSoldierFactoryPort
	{
		IPlayerSoldier Create(ISoldierData soldierData);
	}

}