using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Internal.Ports.Computer;

namespace ProjectB.Gameplay.Internal.Implements.Computer
{

	public class SoldierCombatPowerComputer : ISoldierCombatPowerComputer
	{
		public int ComputeCombatPower(ISoldierData soldierData, SoldierStatus status)
		{
			// soldierData는 현재 사용하지 않으나 향후 반영 가능성을 고려해 파라미터에 포함시킴

			// TODO: 메인 공격력은 가중치 더해주는 처리 추가하기
			
			return (int)(0.1f * status.hp)
			       + 2 * (status.physicalAttack + status.magicalAttack)
			       + status.physicalDefense + status.magicalDefense;
		}
	}

}