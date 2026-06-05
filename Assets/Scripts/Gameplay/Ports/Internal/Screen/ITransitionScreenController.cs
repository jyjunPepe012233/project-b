using System.Collections;

namespace ProjectB.Gameplay.Ports.Internal.Screen
{

	public interface ITransitionScreenController
	{
		IEnumerator LoadAdditive();
		
		IEnumerator Unload();
	}

}