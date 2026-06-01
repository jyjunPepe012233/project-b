using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadSummonAnimationScreenPort
	{
		IEnumerator Load();

		IEnumerator Unload();
	}

}