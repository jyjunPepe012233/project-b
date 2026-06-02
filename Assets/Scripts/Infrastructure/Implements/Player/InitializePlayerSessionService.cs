using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Outbound.Player;
using ProjectB.Infrastructure.Services;

namespace ProjectB.Infrastructure.Implements.Player
{

	public class InitializePlayerSessionService : IInitializePlayerSessionPort
	{
		public void Initialize(IPlayerData playerData)
		{
			PlayerSessionHolder.Initialize(playerData);
		}
	}

}