using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
{

	public class PlayerInfoOverlayService : BaseOverlayService<IPlayerInfoOverlayController>, IPlayerInfoOverlayService
	{
		public PlayerInfoOverlayService(IOverlayManager overlayManager, IPlayerInfoOverlayController controller) : base(overlayManager, controller)
		{
		}
	}

}
