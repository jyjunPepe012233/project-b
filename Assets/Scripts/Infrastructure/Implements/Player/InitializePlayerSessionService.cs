using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class InitializePlayerSessionService : IInitializePlayerSessionPort
	{
		public void Initialize(IPlayerData playerData)
		{
			PlayerSessionHolder.Initialize(playerData);
		}
	}

}