using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class WorldMapOverlayController : EventBasedOverlayController<WorldMapOverlayEvents>, IWorldMapOverlayController
	{
		public WorldMapOverlayController(WorldMapOverlayEvents events) : base(events)
		{
		}
	}

}
