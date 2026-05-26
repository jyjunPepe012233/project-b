using ProjectB.Core.Supports;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class TitleScreenManager : ITitleScreenManagerPort
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