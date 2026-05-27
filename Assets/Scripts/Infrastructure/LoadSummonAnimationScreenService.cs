using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadSummonAnimationScreenService : BaseHomeOverlayScreenService, ILoadSummonAnimationScreenPort
	{
		protected override string OverlayID => "SummonAnimation";
	}

}