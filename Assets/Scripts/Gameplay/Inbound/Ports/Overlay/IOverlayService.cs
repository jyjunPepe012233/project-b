namespace ProjectB.Gameplay.Inbound.Ports.Overlay
{

	public interface IOverlayService
	{
		void Open();
	
		// Overlay를 닫을 때는 현재 가장 상단에 있는 Overlay가 닫히는 것이 자연스러우므로
		// OverlayService의 Close 기능은 OverlayManager에게로 이동됨
//		void Close();
	}

}