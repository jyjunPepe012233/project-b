using System.Collections;

namespace ProjectB.Gameplay.Internal.Ports.Screen
{

	public interface ITransitionScreenController
	{
		IEnumerator LoadAdditive();
		
		IEnumerator Unload();
	}

}