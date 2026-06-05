using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Outbound.Ports.Player
{

	public interface IInitializePlayerSessionPort
	{
		/// <summary>
		/// 플레이어 세션을 초기화함
		/// </summary>
		void Initialize(IPlayerData playerData);
	}

}