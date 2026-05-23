using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadLoadingOverlayServicePort
	{
		IEnumerator Load();

		IEnumerator Unload();
	}

}