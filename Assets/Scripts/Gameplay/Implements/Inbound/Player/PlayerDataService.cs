using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Inbound.Player;
using ProjectB.Gameplay.Ports.Outbound.Player;

namespace ProjectB.Gameplay.Implements.Inbound.Player
{

	public class PlayerDataService : IPlayerDataService
	{
		private readonly IHoldPlayerSessionPort _holdPlayerSessionPort;
		
		public PlayerDataService(IHoldPlayerSessionPort holdPlayerSessionPort)
		{
			_holdPlayerSessionPort = holdPlayerSessionPort;
		}

		public IReadOnlyPlayerData GetPlayerData()
		{
			// IPlayerData가 IReadOnlyPlayerData로 캐스팅
			return _holdPlayerSessionPort.GetPlayerSession().PlayerData;
		}

		public int GetTotalCombatPower()
		{
			int totalCombatPower = 0;
			foreach (var soldier in _holdPlayerSessionPort.GetPlayerSession().PlayerData.Soldiers)
			{
				totalCombatPower += soldier.CombatPower;
			}

			return totalCombatPower;
		}
	}

}