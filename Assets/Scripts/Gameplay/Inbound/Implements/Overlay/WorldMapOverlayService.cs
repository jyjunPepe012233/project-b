using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
{

	public class WorldMapOverlayService : BaseOverlayService<IWorldMapOverlayController>, IWorldMapOverlayService
	{
		public WorldMapOverlayService(IOverlayManager overlayManager, IWorldMapOverlayController controller) : base(overlayManager, controller)
		{
		}
	}

}
