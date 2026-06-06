using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
{

	public class OverlayStackService : IOverlayStackService
	{
		private readonly IOverlayManager _overlayManager;

		public OverlayStackService(IOverlayManager overlayManager)
		{
			_overlayManager = overlayManager;
		}

		public void CloseCurrentOverlay()
		{
			_overlayManager.Close();
		}

		public void CloseAllOverlays()
		{
			_overlayManager.CloseAll();
		}
	}

}