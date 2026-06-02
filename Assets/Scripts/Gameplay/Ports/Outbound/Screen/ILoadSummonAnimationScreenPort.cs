using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound.Screen
{

	public interface ILoadSummonAnimationScreenPort
	{
		IEnumerator Load();

		IEnumerator Unload();
	}

}