using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
{

	public class ShopOverlayService : BaseOverlayService<IShopOverlayController>, IShopOverlayService
	{
		public ShopOverlayService(IOverlayManager overlayManager, IShopOverlayController controller) : base(overlayManager, controller)
		{
		}
	}

}
