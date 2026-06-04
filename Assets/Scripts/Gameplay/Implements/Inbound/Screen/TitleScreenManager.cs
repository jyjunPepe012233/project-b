using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Internal.Screen;

namespace ProjectB.Gameplay.Implements.Inbound.Screen
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