using System;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ISoldierDetailServicePort
	{
		event Action<IReadOnlyPlayerSoldier> SoldierDataUpdateCallback;
		
		void ShowSoldierDetail(ISoldierData soldierData);
	}

}