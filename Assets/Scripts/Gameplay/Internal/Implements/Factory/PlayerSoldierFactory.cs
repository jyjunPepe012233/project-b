using ProjectB.Data.Runtime.Player;
using ProjectB.Data.RuntimeImpl;
using ProjectB.Data.Static.Soldier;
using ProjectB.Gameplay.Internal.Ports.Computer;
using ProjectB.Gameplay.Internal.Ports.Factory;

namespace ProjectB.Gameplay.Internal.Implements.Factory
{

	public class PlayerSoldierFactory : IPlayerSoldierFactoryPort
	{
		private readonly ISoldierCombatPowerComputer _soldierCombatPowerComputer;

		public PlayerSoldierFactory(ISoldierCombatPowerComputer soldierCombatPowerComputer)
		{
			_soldierCombatPowerComputer = soldierCombatPowerComputer;
		}

		public IPlayerSoldier Create(ISoldierData soldierData)
		{
			return new PlayerSoldier(soldierData: soldierData,
				rank: soldierData.BornRank, // 태생 성급을 초기 성급으로 설정하는 처리
				exp: 0,
				level: 1,
				status: soldierData.BaseStatus,
				combatPower: _soldierCombatPowerComputer.ComputeCombatPower(soldierData, soldierData.BaseStatus));
		}
	}

}