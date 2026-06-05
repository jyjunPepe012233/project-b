using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
{

	public class ShopOverlayService : BaseOverlayService<IShopOverlayController>, IShopOverlayService
	{
		public ShopOverlayService(IShopOverlayController controller) : base(controller)
		{
		}
	}

}
