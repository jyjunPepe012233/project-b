using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class BackpackOverlayController : EventBasedOverlayController<BackpackOverlayEvents>, IBackpackOverlayController
	{
		public BackpackOverlayController(BackpackOverlayEvents events) : base(events)
		{
		}
	}

}
