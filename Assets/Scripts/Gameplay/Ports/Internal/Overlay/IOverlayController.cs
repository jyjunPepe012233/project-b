using System.Collections;

namespace ProjectB.Gameplay.Ports.Internal.Overlay
{

	public interface IOverlayController
	{ 
		IEnumerator Open();

		IEnumerator Close();
	}

}