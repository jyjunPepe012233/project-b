using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound.Screen
{

	public interface ILoadShopScreenServicePort
	{
		IEnumerator Load();

		IEnumerator Unload();
	}

}