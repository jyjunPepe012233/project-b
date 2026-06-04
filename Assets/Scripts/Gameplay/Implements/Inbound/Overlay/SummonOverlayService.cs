using ProjectB.Gameplay.Implements.Internal.Overlay;
using ProjectB.Gameplay.Ports.Inbound.Overlay;
using ProjectB.Gameplay.Ports.Internal.Overlay;

namespace ProjectB.Gameplay.Implements.Inbound.Overlay
{

	public class SummonOverlayService : BaseOverlayService<SummonOverlayController>, ISummonOverlayService
	{
		public SummonOverlayService(SummonOverlayController controller) : base(controller)
		{
		}
	}

}