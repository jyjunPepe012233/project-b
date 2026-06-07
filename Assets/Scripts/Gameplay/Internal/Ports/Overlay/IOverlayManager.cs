using System.Collections;

namespace ProjectB.Gameplay.Internal.Ports.Overlay
{

	public interface IOverlayManager
	{
		public IOverlayController CurrentOverlay { get; }
		
		IEnumerator Open(IOverlayController overlayController);
		
		IEnumerator Close();

		IEnumerator CloseAll();
	}

}