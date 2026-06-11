using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
{

	public class BackpackOverlayService : BaseOverlayService<IBackpackOverlayController>, IBackpackOverlayService
	{
		public BackpackOverlayService(IOverlayManager overlayManager, IBackpackOverlayController controller) : base(overlayManager, controller)
		{
		}
	}

}
