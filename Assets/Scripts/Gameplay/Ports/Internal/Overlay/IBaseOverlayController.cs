using System.Collections;

namespace ProjectB.Gameplay.Ports.Internal.Overlay
{

	public interface IBaseOverlayController
	{
		IEnumerator Open();

		IEnumerator Close();
	}

}