using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Outbound.Player
{

	public interface IHoldPlayerSessionPort
	{
		IPlayerSession GetPlayerSession();
	}

}