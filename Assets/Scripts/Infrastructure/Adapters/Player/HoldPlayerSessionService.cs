using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Outbound.Ports.Player;
using ProjectB.Infrastructure.SessionHolder;

namespace ProjectB.Infrastructure.Adapters.Player
{

	public class HoldPlayerSessionService : IHoldPlayerSessionPort
	{
		public IPlayerSession GetPlayerSession()
		{
			return PlayerSessionHolder.PlayerSession;
		}
	}

}