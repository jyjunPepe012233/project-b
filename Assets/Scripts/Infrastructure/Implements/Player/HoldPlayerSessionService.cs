using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Outbound.Player;
using ProjectB.Infrastructure.Services;

namespace ProjectB.Infrastructure.Implements.Player
{

	public class HoldPlayerSessionService : IHoldPlayerSessionPort
	{
		public IPlayerSession GetPlayerSession()
		{
			return PlayerSessionHolder.PlayerSession;
		}
	}

}