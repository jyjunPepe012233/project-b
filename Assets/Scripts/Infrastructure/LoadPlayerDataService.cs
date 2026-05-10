using ProjectB.Data.Runtime.Player;
using ProjectB.Data.RuntimeImpl;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadPlayerDataService : ILoadPlayerDataPort
	{
		public IPlayerData LoadPlayerData()
		{
			return new PlayerData(coins: 9999, gems: 9999, morale: 999, foods: 99999); // TODO: 서버에서 받아오거나 로컬에 저장된거 역직렬화
		}
	}

}