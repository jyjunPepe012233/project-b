using ProjectB.Core.Supports;
using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Gameplay.Ports.Outbound.Screen;

namespace ProjectB.Gameplay.Implements.Inbound.Screen
{
	
	public class TitleScreenManager : ITitleScreenManager
	{
		private readonly ILoadHomeScreenPort _loadHomeScreenScenePort;
		private readonly ILoadingTransitionServicePort _loadingTransitionServicePort;
		
		public TitleScreenManager(ILoadHomeScreenPort loadHomeScreenPort, ILoadingTransitionServicePort loadingTransitionServicePort)
		{
			_loadHomeScreenScenePort = loadHomeScreenPort;
			_loadingTransitionServicePort = loadingTransitionServicePort;
		}

		public void Touched()
		{
			LoadHomeWithTransition();
		}

		void LoadHomeWithTransition()
		{
			var loadingTask = _loadHomeScreenScenePort.GetLoadingTask();
			CoroutineHandler.StartAndAdd(_loadingTransitionServicePort.LoadScreenWithTransition(loadingTask));
		}
	}

}