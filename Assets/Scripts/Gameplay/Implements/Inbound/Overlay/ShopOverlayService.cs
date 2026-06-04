using ProjectB.Gameplay.Implements.Internal.Overlay;
using ProjectB.Gameplay.Ports.Inbound.Overlay;

namespace ProjectB.Gameplay.Implements.Inbound.Overlay
{

	public class ShopOverlayService : BaseOverlayService<ShopOverlayController>, IShopOverlayService
	{
		public ShopOverlayService(ShopOverlayController controller) : base(controller)
		{
		}
	}

}
