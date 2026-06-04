using System;

namespace ProjectB.Gameplay.Events.Overlay
{

	public class WorldMapOverlayEvents : IOverlayEvents
	{
		public Action Open { get; set; }
		
		public Action Close { get; set; }
	}

}
