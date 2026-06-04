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
		private readonly ILoadingTransitionService _loadingTransitionService;
		
		public TitleScreenManager(ILoadHomeScreenPort loadHomeScreenPort, ILoadingTransitionService loadingTransitionService)
		{
			_loadHomeScreenScenePort = loadHomeScreenPort;
			_loadingTransitionService = loadingTransitionService;
		}

		public void Touched()
		{
			LoadHomeWithTransition();
		}

		void LoadHomeWithTransition()
		{
			var loadingTask = _loadHomeScreenScenePort.GetLoadingTask();
			CoroutineHandler.StartAndAdd(_loadingTransitionService.LoadScreenWithTransition(loadingTask));
		}
	}

}