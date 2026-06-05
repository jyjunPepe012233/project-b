using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class SummonOverlayController : EventBasedOverlayController<SummonOverlayEvents>, ISummonOverlayController
	{
		public SummonOverlayController(SummonOverlayEvents events) : base(events)
		{
		}
	}

}