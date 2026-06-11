using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class PlayerInfoOverlayController : EventBasedOverlayController<PlayerInfoOverlayEvents>, IPlayerInfoOverlayController
	{
		public PlayerInfoOverlayController(PlayerInfoOverlayEvents events) : base(events)
		{
		}
	}

}
