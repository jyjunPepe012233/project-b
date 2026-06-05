using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Outbound.Ports.Player
{

	public interface IHoldPlayerSessionPort
	{
		IPlayerSession GetPlayerSession();
	}

}