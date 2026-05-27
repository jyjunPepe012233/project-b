using System.Collections;
using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadSoldierDetailScreenPort
	{
		bool IsLoaded { get; }
		
		IEnumerator Load();

		IEnumerator Unload();
	}

}