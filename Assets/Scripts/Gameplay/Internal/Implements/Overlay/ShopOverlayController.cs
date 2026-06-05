using ProjectB.Gameplay.Events.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class ShopOverlayController : EventBasedOverlayController<ShopOverlayEvents>
	{
		public ShopOverlayController(ShopOverlayEvents events) : base(events)
		{
		}
	}

}
