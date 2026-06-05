using ProjectB.Gameplay.Events.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class SoldierListOverlayController : EventBasedOverlayController<SoldierListOverlayEvents>
	{
		public SoldierListOverlayController(SoldierListOverlayEvents events) : base(events)
		{
		}
	}

}
