using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Outbound.Player
{

	public interface IPlayerSessionHolderPort
	{
		IPlayerSession GetPlayerSession();
	}

}