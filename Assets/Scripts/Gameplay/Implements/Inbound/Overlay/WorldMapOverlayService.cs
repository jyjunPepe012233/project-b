using ProjectB.Gameplay.Implements.Internal.Overlay;
using ProjectB.Gameplay.Ports.Inbound.Overlay;

namespace ProjectB.Gameplay.Implements.Inbound.Overlay
{

	public class WorldMapOverlayService : BaseOverlayService<WorldMapOverlayController>, IWorldMapOverlayService
	{
		public WorldMapOverlayService(WorldMapOverlayController controller) : base(controller)
		{
		}
	}

}
