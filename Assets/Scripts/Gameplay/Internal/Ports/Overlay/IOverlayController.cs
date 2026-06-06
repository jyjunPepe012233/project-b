using System.Collections;

namespace ProjectB.Gameplay.Internal.Ports.Overlay
{
	// WARNING:
	//   IOverlayController를 직접 사용해서 Overlay를 열고 닫지는 않아야 함.
	//   IOverlayController를 IOverlayManager에게 넘겨서 조작해야 스택 관리가 제대로 이루어짐
	
	public interface IOverlayController
	{ 
		// Overlay를 열고 싶을 때 사용하는 메서드
		IEnumerator Open();

		// Overlay를 닫고 싶을 때 사용하는 메서드 
		IEnumerator Close();
		
		// Overlay가 스택에서 밀려났다가 화면에서 보여질 때 사용되는 메서드
		IEnumerator Show();

		// Overlay가 스택에서 밀려나서 화면에서 사라질 때 사용되는 메서드
		IEnumerator Hide();
	}

}