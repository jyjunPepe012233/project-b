using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadShopScreenService : BaseHomeOverlayScreenService, ILoadShopScreenServicePort
	{
		protected override string OverlayID => "Shop";
	}

}