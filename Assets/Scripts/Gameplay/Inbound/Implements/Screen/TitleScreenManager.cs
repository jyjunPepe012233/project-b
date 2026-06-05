using ProjectB.Gameplay.Inbound.Ports.Screen;
using ProjectB.Gameplay.Internal.Ports;
using ProjectB.Gameplay.Internal.Ports.Screen;

namespace ProjectB.Gameplay.Inbound.Implements.Screen
{
	
	public class TitleScreenManager : ITitleScreenManager
	{
		private readonly IHomeScreenLoader _homeScreenLoader;
		private readonly IChangeScreenTransitionService _changeScreenTransitionService;
		
		public TitleScreenManager(IHomeScreenLoader homeScreenLoader, IChangeScreenTransitionService changeScreenTransitionService)
		{
			_homeScreenLoader = homeScreenLoader;
			_changeScreenTransitionService = changeScreenTransitionService;
		}

		public void Touched()
		{
			LoadHomeWithTransition();
		}

		void LoadHomeWithTransition()
		{
			_changeScreenTransitionService.ChangeScreenWithTransition(_homeScreenLoader.Load);
		}
	}

}