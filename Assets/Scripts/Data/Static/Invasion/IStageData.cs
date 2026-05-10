using System.Collections.Generic;
using ProjectB.Data.Types;

namespace ProjectB.Data.Static.Invasion
{

	public interface IStageData
	{
		string StageName { get; }
		
		int CoinReward { get; } // 실제로는 ISweepSetting에 명시된 noise에 따라 변동이 있음
		
		IEnumerable<ItemGain> ItemRewards { get; }
	}

}