using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Outbound.Ports.Player;
using ProjectB.Infrastructure.Services;

namespace ProjectB.Infrastructure.Adapters.Player
{

	public class InitializePlayerSessionService : IInitializePlayerSessionPort
	{
		public void Initialize(IPlayerData playerData)
		{
			PlayerSessionHolder.Initialize(playerData);
		}
	}

}