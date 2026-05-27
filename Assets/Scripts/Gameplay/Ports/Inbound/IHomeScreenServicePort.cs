namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IHomeScreenServicePort
	{
		void OpenSummonScreen();

		void CloseSummonScreen();
		
		
		void OpenShopScreen();
		
		void CloseShopScreen();
		
		
		void OpenSoldierListScreen();
		
		void CloseSoldierListScreen();
		
		
		void OpenWorldMapScreen();
		
		void CloseWorldMapScreen();
	}

}