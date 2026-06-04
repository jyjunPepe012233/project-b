using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Ports.Internal.Overlay;

namespace ProjectB.Gameplay.Implements.Internal.Overlay
{

	public class SoldierDetailOverlayController : EventBasedOverlayController<SoldierDetailOverlayEvents>, ISoldierDetailOverlayController
	{
		public SoldierDetailOverlayController(SoldierDetailOverlayEvents events) : base(events)
		{
		}
	}

}