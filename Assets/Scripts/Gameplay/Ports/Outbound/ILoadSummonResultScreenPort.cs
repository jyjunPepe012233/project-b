using System.Collections;
using ProjectB.Data.Runtime.Summon;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadSummonResultScreenPort
	{
		bool IsLoaded { get; }
		
		IEnumerator Load();
		
		IEnumerator Unload();
	}

}