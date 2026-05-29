using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay.Implements.Inbound.Screen
{

	public class ShopScreenService : IShopScreenService
	{
		private readonly ILoadShopScreenServicePort _loadShopScreenServicePort;

		public ShopScreenService(ILoadShopScreenServicePort loadShopScreenServicePort)
		{
			_loadShopScreenServicePort = loadShopScreenServicePort;
		}

		public void Open()
		{
			_loadShopScreenServicePort.Load();
		}

		public void Close()
		{
			_loadShopScreenServicePort.Unload();
		}
	}

}