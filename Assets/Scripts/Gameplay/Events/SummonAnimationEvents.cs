using System;
using ProjectB.Data.Runtime.Summon;

namespace ProjectB.Gameplay.Events
{

	public class SummonAnimationEvents
	{
		public Action<SummonResult> StartAnimation; // Animation 시작 요청에 모집 결과를 전달하기 위해 제네릭 사용 
		
		public Action AnimationFinished;
	}

}