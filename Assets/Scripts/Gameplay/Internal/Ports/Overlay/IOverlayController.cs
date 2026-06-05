using System.Collections;

namespace ProjectB.Gameplay.Internal.Ports.Overlay
{

	public interface IOverlayController
	{ 
		IEnumerator Open();

		IEnumerator Close();
	}

}