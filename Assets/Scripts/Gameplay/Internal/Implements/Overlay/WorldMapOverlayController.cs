using ProjectB.Gameplay.Events.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class WorldMapOverlayController : EventBasedOverlayController<WorldMapOverlayEvents>
	{
		public WorldMapOverlayController(WorldMapOverlayEvents events) : base(events)
		{
		}
	}

}
