using System.Collections;

namespace ProjectB.Gameplay.Ports.Internal.Screen
{

	public interface ILoadingScreenController
	{
		IEnumerator LoadAdditive();
		
		IEnumerator Unload();
	}

}