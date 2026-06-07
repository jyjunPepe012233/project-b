using ProjectB.Core.Supports;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;
using UnityEngine;

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
			CoroutineHandler.StartAndAdd(_overlayManager.Close());
		}

		public void CloseAllOverlays()
		{
			CoroutineHandler.StartAndAdd(_overlayManager.CloseAll());
		}
	}

}