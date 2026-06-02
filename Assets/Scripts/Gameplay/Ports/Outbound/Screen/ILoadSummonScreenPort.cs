using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound.Screen
{

	public interface ILoadSummonScreenPort
	{
		IEnumerator Load();
		
		IEnumerator Unload();
	}

}