using ProjectB.Gameplay.Events.Overlay;

namespace ProjectB.Gameplay.Implements.Internal.Overlay
{

	public class WorldMapOverlayController : EventBasedOverlayController<WorldMapOverlayEvents>
	{
		public WorldMapOverlayController(WorldMapOverlayEvents events) : base(events)
		{
		}
	}

}
