using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadSummonResultScreenService : BaseHomeOverlayScreenService, ILoadSummonResultScreenPort
	{
		protected override string OverlayID => "SummonResult";
	}

}