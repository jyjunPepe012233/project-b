using ProjectB.Core.Supports;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Inbound.Implements.Overlay
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