using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadSoldierListScreenService : BaseHomeOverlayScreenService, ILoadSoldierListScreenServicePort
	{
		protected override string OverlayID => "SoldierList";
	}

}