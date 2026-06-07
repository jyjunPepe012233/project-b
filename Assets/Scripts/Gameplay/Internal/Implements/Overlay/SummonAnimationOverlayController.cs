using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class SummonAnimationOverlayController : EventBasedOverlayController<SummonAnimationOverlayEvents>, ISummonAnimationOverlayController
	{
		public SummonAnimationOverlayController(SummonAnimationOverlayEvents events) : base(events)
		{
		}
	}

}