using ProjectB.Gameplay.Events.Overlay;

namespace ProjectB.Gameplay.Implements.Internal.Overlay
{

	public class ShopOverlayController : EventBasedOverlayController<ShopOverlayEvents>
	{
		public ShopOverlayController(ShopOverlayEvents events) : base(events)
		{
		}
	}

}
