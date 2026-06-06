using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class ShopOverlayController : EventBasedOverlayController<ShopOverlayEvents>, IShopOverlayController
	{
		public ShopOverlayController(ShopOverlayEvents events) : base(events)
		{
		}
	}

}
