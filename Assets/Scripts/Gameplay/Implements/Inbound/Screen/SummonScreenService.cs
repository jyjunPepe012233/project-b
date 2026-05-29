using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay.Implements.Inbound.Screen
{

	public class SummonScreenService : ISummonScreenService
	{
		private readonly ILoadSummonScreenPort _loadSummonScreenPort;

		public SummonScreenService(ILoadSummonScreenPort loadSummonScreenPort)
		{
			_loadSummonScreenPort = loadSummonScreenPort;
		}

		public void Open()
		{
			_loadSummonScreenPort.Load();
		}

		public void Close()
		{
			_loadSummonScreenPort.Unload();
		}
	}

}