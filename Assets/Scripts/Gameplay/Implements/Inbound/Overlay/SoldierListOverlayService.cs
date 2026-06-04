using ProjectB.Gameplay.Implements.Internal.Overlay;
using ProjectB.Gameplay.Ports.Inbound.Overlay;

namespace ProjectB.Gameplay.Implements.Inbound.Overlay
{

	public class SoldierListOverlayService : BaseOverlayService<SoldierListOverlayController>, ISoldierListOverlayService
	{
		public SoldierListOverlayService(SoldierListOverlayController controller) : base(controller)
		{
		}
	}

}
