using ProjectB.Data.Runtime.Player;
using ProjectB.Data.RuntimeImpl;
using ProjectB.Gameplay.Ports.Outbound.Player;

namespace ProjectB.Infrastructure.Implements.Player
{

	public class TestLoadPlayerDataService : ILoadPlayerDataPort
	{
		public IPlayerData LoadPlayerData()
		{
			return new PlayerData( // TODO: 서버에서 받아오거나 로컬에 저장된거 역직렬화
				playerName: "진예준",
				level: 1,
				experience: 0,
				coins: 9999,
				gems: 9999,
				morale: 999,
				foods: 99999
			);
		}
	}

}