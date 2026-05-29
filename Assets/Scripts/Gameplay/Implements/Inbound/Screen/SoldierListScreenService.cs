using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay.Implements.Inbound.Screen
{

	public class SoldierListScreenService : ISoldierListScreenService
	{
		private readonly ILoadSoldierListScreenServicePort _loadSoldierListScreenServicePort;

		public SoldierListScreenService(ILoadSoldierListScreenServicePort loadSoldierListScreenServicePort)
		{
			_loadSoldierListScreenServicePort = loadSoldierListScreenServicePort;
		}

		public void Open()
		{
			_loadSoldierListScreenServicePort.Load();
		}

		public void Close()
		{ 
			_loadSoldierListScreenServicePort.Unload();
		}
	}

}