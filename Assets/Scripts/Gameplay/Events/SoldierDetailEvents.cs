using System;
using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Events
{

	public class SoldierDetailEvents
	{
		public Action<IReadOnlyPlayerSoldier> SelectSoldier;
	}

}