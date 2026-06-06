using System;

namespace ProjectB.Gameplay.Events.Overlay
{

	public abstract class BaseOverlayEvents : IOverlayEvents
	{
		public Action Open { get; set; }
		public Action Close { get; set; }
		public Action Show { get; set; }
		public Action Hide { get; set; }
	}

}