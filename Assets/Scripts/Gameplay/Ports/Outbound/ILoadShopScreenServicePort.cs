using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadShopScreenServicePort
	{
		IEnumerator Load();

		IEnumerator Unload();
	}

}