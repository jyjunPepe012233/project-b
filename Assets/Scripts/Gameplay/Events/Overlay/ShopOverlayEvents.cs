using System;

namespace ProjectB.Gameplay.Events.Overlay
{

	public class ShopOverlayEvents : IOverlayEvents
	{
		public Action Open { get; set; }
		
		public Action Close { get; set; }
	}

}
