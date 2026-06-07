using ProjectB.Data.Runtime.Player;
using ProjectB.Data.RuntimeImpl;

namespace ProjectB.Infrastructure.SessionHolder
{

	public static class PlayerSessionHolder
	{
		public static PlayerSession PlayerSession { get; private set; }

		public static bool HasInitialized { get; private set; }

		public static PlayerSession Initialize(IPlayerData playerData)
		{
			PlayerSession = new PlayerSession(playerData);
			HasInitialized = true;
			return PlayerSession;
		}
	}

}