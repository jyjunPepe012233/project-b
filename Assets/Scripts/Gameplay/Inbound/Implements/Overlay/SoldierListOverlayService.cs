using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
{

	public class SoldierListOverlayService : BaseOverlayService<ISoldierListOverlayController>, ISoldierListOverlayService
	{
		public SoldierListOverlayService(IOverlayManager overlayManager, ISoldierListOverlayController controller) : base(overlayManager, controller)
		{
		}
	}

}
