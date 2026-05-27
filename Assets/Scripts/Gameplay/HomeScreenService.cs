using ProjectB.Core.Supports;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay
{
	// BaseHomeScreenPresenter -> ButtonView(BackToLobbyButton)

	public class HomeScreenService : IHomeScreenServicePort
	{
		private readonly ILoadSummonScreenPort _loadSummonScreenPort;
		private readonly ILoadShopScreenServicePort _loadShopScreenServicePort;
		private readonly ILoadSoldierListScreenServicePort _loadSoldierListScreenServicePort;
		private readonly ILoadWorldMapScreenServicePort _loadWorldMapScreenServicePort;


		public void OpenSummonScreen()
		{
			CoroutineHandler.StartAndAdd(_loadSummonScreenPort.Load());
		}

		public void CloseSummonScreen()
		{
			CoroutineHandler.StartAndAdd(_loadSummonScreenPort.Unload());
		}
		

		public void OpenShopScreen()
		{
			CoroutineHandler.StartAndAdd(_loadShopScreenServicePort.Load());
		}

		public void CloseShopScreen()
		{
			CoroutineHandler.StartAndAdd(_loadShopScreenServicePort.Unload());
		}

		
		public void OpenSoldierListScreen()
		{
			CoroutineHandler.StartAndAdd(_loadSoldierListScreenServicePort.Load());
		}

		public void CloseSoldierListScreen()
		{
			CoroutineHandler.StartAndAdd(_loadSoldierListScreenServicePort.Unload());
		}
		

		public void OpenWorldMapScreen()
		{
			CoroutineHandler.StartAndAdd(_loadWorldMapScreenServicePort.Load());
		}

		public void CloseWorldMapScreen()
		{
			CoroutineHandler.StartAndAdd(_loadWorldMapScreenServicePort.Unload());
		}
	}

}