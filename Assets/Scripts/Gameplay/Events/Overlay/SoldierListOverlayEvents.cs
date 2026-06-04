using System;

namespace ProjectB.Gameplay.Events.Overlay
{

	public class SoldierListOverlayEvents : IOverlayEvents
	{
		public Action Open { get; set; }
		
		public Action Close { get; set; }
	}

}
