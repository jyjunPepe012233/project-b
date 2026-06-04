using ProjectB.Core.Supports;
using ProjectB.Gameplay.Ports.Internal.Overlay;

namespace ProjectB.Gameplay.Implements.Inbound.Overlay
{

	public abstract class BaseOverlayService<TController> where TController : IOverlayController
	{
		protected readonly TController _controller;

		protected BaseOverlayService(TController controller)
		{
			_controller = controller;
		}
		
		public void Open()
		{
			CoroutineHandler.StartAndAdd(_controller.Open());
		}

		public void Close()
		{
			CoroutineHandler.StartAndAdd(_controller.Close());
		}
	}

}