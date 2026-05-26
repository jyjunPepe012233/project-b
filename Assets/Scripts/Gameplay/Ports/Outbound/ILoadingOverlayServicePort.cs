using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadingOverlayServicePort
	{
		IEnumerator Load();

		IEnumerator OpenTransition(); // Fade In 시작
		
		IEnumerator CloseTransition(); // Fade Out 시작
		
		IEnumerator Unload();
	}

}