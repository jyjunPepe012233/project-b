using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound.Screen
{

	public interface ILoadWorldMapScreenServicePort
	{
		IEnumerator Load();

		IEnumerator Unload();
	}

}