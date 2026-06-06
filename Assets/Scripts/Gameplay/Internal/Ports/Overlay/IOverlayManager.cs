using System.Collections;

namespace ProjectB.Gameplay.Internal.Ports.Overlay
{

	public interface IOverlayManager
	{ 
		IEnumerator Open(IOverlayController overlayController);
		
		IEnumerator Close();

		IEnumerator CloseAll();
	}

}