using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Ports.Internal.Overlay;

namespace ProjectB.Gameplay.Implements.Internal.Overlay
{

	public class SummonOverlayController : EventBasedOverlayController<SummonOverlayEvents>, ISummonOverlayController
	{
		public SummonOverlayController(SummonOverlayEvents events) : base(events)
		{
		}
	}

}