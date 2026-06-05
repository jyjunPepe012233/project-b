using System;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Inbound.Ports
{

	public interface ISummonService
	{
		// 모집 결과를 플레이어에게 제공하는 시점에서 Manager가 외부로 알리는 메서드
		event Action<SummonResult> ShowSummonResult;
		
		void Summon(SummonType type);
	}

}