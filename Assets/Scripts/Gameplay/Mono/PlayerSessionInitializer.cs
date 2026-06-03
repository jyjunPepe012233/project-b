using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Gameplay.Ports.Outbound.Player;

namespace ProjectB.Gameplay
{

	public class PlayerSessionInitializer
	{
		private readonly IInitializePlayerSessionPort _initializePlayerSessionPort;
		private readonly ILoadPlayerDataPort _loadPlayerDataPort;
		
		public PlayerSessionInitializer(IInitializePlayerSessionPort initializePlayerSessionPort,
			ILoadPlayerDataPort loadPlayerDataPort)
		{
			_initializePlayerSessionPort = initializePlayerSessionPort;
			_loadPlayerDataPort = loadPlayerDataPort;
			
			Initialize();
		}

		void Initialize()
		{
			// LoadPlayerData를 통해 외부 저장소에서 플레이어 데이터를 불러옴
			// 불러온 데이터를 메모리 상에 저장되는 런타임 데이터인 PlayerSession으로 저장
			
			_initializePlayerSessionPort.Initialize(_loadPlayerDataPort.LoadPlayerData());
		}
	}

}