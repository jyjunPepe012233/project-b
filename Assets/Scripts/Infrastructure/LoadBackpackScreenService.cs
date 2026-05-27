using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadBackpackScreenService : BaseHomeOverlayScreenService, ILoadBackpackScreenPort
	{
		protected override string OverlayID => "Backpack"; 
	}

}