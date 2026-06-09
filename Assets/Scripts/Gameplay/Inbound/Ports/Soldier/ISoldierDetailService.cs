using System;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Inbound.Ports.Soldier
{

	public interface ISoldierDetailService
	{
		void ShowSoldierDetail(ISoldierData soldierData);
	}

}