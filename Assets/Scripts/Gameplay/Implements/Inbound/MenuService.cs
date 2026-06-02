using ProjectB.Core.Supports;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound.Screen;

namespace ProjectB.Gameplay.Implements.Inbound
{

	public class MenuService : IMenuServicePort
	{
		private readonly ILoadBackpackScreenPort _loadBackpackScreenPort;

		public MenuService(ILoadBackpackScreenPort loadBackpackScreenPort)
		{
			_loadBackpackScreenPort = loadBackpackScreenPort;
		}

		public void OpenBackpack()
		{
			CoroutineHandler.StartAndAdd(_loadBackpackScreenPort.Load());
		}
	}

}