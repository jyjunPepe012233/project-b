using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound.Screen
{

	public interface ILoadSoldierDetailScreenPort
	{
		bool IsLoaded { get; }
		
		IEnumerator Load();

		IEnumerator Unload();
	}

}