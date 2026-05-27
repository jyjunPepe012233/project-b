using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadWorldMapScreenServicePort
	{
		IEnumerator Load();

		IEnumerator Unload();
	}

}