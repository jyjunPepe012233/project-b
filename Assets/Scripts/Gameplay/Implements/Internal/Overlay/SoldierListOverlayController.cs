using ProjectB.Gameplay.Events.Overlay;

namespace ProjectB.Gameplay.Implements.Internal.Overlay
{

	public class SoldierListOverlayController : EventBasedOverlayController<SoldierListOverlayEvents>
	{
		public SoldierListOverlayController(SoldierListOverlayEvents events) : base(events)
		{
		}
	}

}
