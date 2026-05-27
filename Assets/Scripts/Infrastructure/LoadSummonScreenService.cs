using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadSummonScreenService : BaseHomeOverlayScreenService, ILoadSummonScreenPort
	{
		protected override string OverlayID => "SummonScreen"; // TODO: 얘만 "Summon"이 아니라 "SummonScreen"임. 수정 필요
	}

}