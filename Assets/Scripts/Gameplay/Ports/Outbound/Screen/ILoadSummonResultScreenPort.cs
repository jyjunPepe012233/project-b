using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound.Screen
{

	public interface ILoadSummonResultScreenPort
	{
		bool IsLoaded { get; }
		
		IEnumerator Load();
		
		IEnumerator Unload();
	}

}