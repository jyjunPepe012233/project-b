using System;

namespace ProjectB.Gameplay.Events.Overlay
{

	public class SummonOverlayEvents : IOverlayEvents
	{
		public Action Open { get; set; }
		
		public Action Close { get; set; }
	}

}