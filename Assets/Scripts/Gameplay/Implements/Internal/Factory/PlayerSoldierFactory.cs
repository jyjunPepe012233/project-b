using ProjectB.Data.Runtime.Player;
using ProjectB.Data.RuntimeImpl;
using ProjectB.Data.Static.Soldier;
using ProjectB.Gameplay.Ports.Internal;

namespace ProjectB.Gameplay
{

	public class PlayerSoldierFactory : IPlayerSoldierFactoryPort
	{
		private readonly ISoldierCombatPowerComputerPort _soldierCombatPowerComputerPort;

		public PlayerSoldierFactory(ISoldierCombatPowerComputerPort soldierCombatPowerComputerPort)
		{
			_soldierCombatPowerComputerPort = soldierCombatPowerComputerPort;
		}

		public IPlayerSoldier Create(ISoldierData soldierData)
		{
			return new PlayerSoldier(soldierData: soldierData,
				rank: soldierData.BornRank, // 태생 성급을 초기 성급으로 설정하는 처리
				exp: 0,
				level: 1,
				status: soldierData.BaseStatus,
				combatPower: _soldierCombatPowerComputerPort.ComputeCombatPower(soldierData, soldierData.BaseStatus));
		}
	}

}