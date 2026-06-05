using System;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Inbound.Ports.Soldier
{

	public interface ISoldierDetailService
	{
		event Action<IReadOnlyPlayerSoldier> SoldierDataUpdateCallback;
		
		void ShowSoldierDetail(ISoldierData soldierData);
	}

}