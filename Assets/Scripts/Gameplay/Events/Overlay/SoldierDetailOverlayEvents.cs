using System;

namespace ProjectB.Gameplay.Events.Overlay
{

	public class SoldierDetailOverlayEvents : IOverlayEvents
	{
		public Action Open { get; set; }
		
		public Action Close { get; set; }
	}

}