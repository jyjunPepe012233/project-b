using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
{

	public class SummonOverlayService : BaseOverlayService<ISummonOverlayController>, ISummonOverlayService
	{
		public SummonOverlayService(IOverlayManager overlayManager, ISummonOverlayController controller) : base(overlayManager, controller)
		{
		}
	}

}