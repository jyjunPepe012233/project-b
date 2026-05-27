using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadWorldMapScreenService : BaseHomeOverlayScreenService, ILoadWorldMapScreenServicePort
	{
		protected override string OverlayID => "WorldMap";
	}

}