using System;
using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Events
{

	public class SoldierInfoEvents
	{
		public Action<IPlayerSoldier> ExpUpdated;
		
		public Action<IPlayerSoldier> LevelUpdated;
		
		public Action<IPlayerSoldier> StatusUpdated;
	}

}