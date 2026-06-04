using System;
using ProjectB.Data.Runtime.Summon;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ISummonAnimationManager
	{
		// 애니메이션이 시작되면 Manager가 외부로 알리는 이벤트
		event Action<SummonResult> StartAnimation;
		
		// 애니메이션이 끝나면 Manager가 외부로 알리는 이벤트
		event Action AnimationPerfectlyUnloaded;

		// 애니메이션의 주체(UI, 애니메이션 오브젝트 등)가 애니메이션이 끝났음을 Manager에게 알리는 메서드
		// Manager는 이 메서드를 통해 애니메이션이 끝났음을 인지하고 AnimationPerfectlyUnloaded 이벤트를 트리거함
		void FinishAnimation();
	}

}