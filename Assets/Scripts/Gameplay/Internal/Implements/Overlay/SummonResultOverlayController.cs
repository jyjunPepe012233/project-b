using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class SummonResultOverlayController : EventBasedOverlayController<SummonResultOverlayEvents>, ISummonResultOverlayController
	{
		public SummonResultOverlayController(SummonResultOverlayEvents events) : base(events)
		{
		}
	}

}