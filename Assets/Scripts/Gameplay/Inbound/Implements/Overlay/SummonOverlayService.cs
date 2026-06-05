using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
{

	public class SummonOverlayService : BaseOverlayService<ISummonOverlayController>, ISummonOverlayService
	{
		public SummonOverlayService(ISummonOverlayController controller) : base(controller)
		{
		}
	}

}