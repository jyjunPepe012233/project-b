using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadSoldierListScreenServicePort
	{
		IEnumerator Load();

		IEnumerator Unload();
	}

}