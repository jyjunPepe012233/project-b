using System.Collections;

namespace ProjectB.Gameplay.Implements.Internal.Overlay
{

	public interface IOverlayController
	{ 
		IEnumerator Open();

		IEnumerator Close();
	}

}