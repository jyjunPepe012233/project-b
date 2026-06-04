using System;

namespace ProjectB.Gameplay.Events.Overlay
{

	public interface IOverlayEvents
	{
		Action Open { get; set; }
		
		Action Close { get; set; }
	}

}