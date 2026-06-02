using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Outbound.Player;

namespace ProjectB.Infrastructure.Implements.Player
{

	public class PlayerSessionHolderService : IPlayerSessionHolderPort
	{
		public IPlayerSession GetPlayerSession()
		{
			return PlayerSessionHolder.PlayerSession;
		}
	}

}