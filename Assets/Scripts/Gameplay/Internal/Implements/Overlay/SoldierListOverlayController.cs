using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class SoldierListOverlayController : EventBasedOverlayController<SoldierListOverlayEvents>, ISoldierListOverlayController
	{
		public SoldierListOverlayController(SoldierListOverlayEvents events) : base(events)
		{
		}
	}

}
