using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound.Screen
{

	public interface ILoadSoldierListScreenServicePort
	{
		IEnumerator Load();

		IEnumerator Unload();
	}

}