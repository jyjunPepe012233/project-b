using ProjectB.Core.Supports;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
{

	public abstract class BaseOverlayService<TController> where TController : IOverlayController
	{
		protected readonly IOverlayManager _overlayManager;
		protected readonly TController _controller;

		protected BaseOverlayService(IOverlayManager overlayManager, TController controller)
		{
			_overlayManager = overlayManager;
			_controller = controller;
		}
		
		public void Open()
		{
			CoroutineHandler.StartAndAdd(_overlayManager.Open(_controller));
		}
	}

}