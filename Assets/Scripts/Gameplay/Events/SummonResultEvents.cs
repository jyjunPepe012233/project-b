using System;
using ProjectB.Data.Runtime.Summon;

namespace ProjectB.Gameplay.Events
{

	public class SummonResultEvents
	{
		// SummonService가 모집 연출 이후 모집 결과 화면을 띄울 때 호출하는 이벤트
		public Action<SummonResult> ShowSummonResult;
	}

}