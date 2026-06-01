using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class PlayerSessionHolderService : IPlayerSessionHolderPort
	{
		public IPlayerSession GetPlayerSession()
		{
			return PlayerSessionHolder.PlayerSession;
		}
	}

}