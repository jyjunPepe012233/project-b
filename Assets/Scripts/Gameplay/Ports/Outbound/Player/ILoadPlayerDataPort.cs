using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Outbound
{

	// 왜 플레이어의 데이터를 저장하는 Port는 데이터 별로 분리되었고,
	// 플레이어의 데이터를 불러오는 Port는 (이 인터페이스를 통해) 통합되었나?
	// 모르겠음. 일단 해보지 뭐.
	
	public interface ILoadPlayerDataPort
	{
		/// <summary>
		/// 외부 저장소에서 플레이어의 데이터를 불러옴
		/// </summary>
		IPlayerData LoadPlayerData();
	}

}