using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;

namespace ProjectB.Dependency
{

	public partial class GlobalLifetimeScope
	{
		void RegisterEvents()
		{
			// 분류 X
			RegisterMonoSystem<ChangeScreenTransitionEvents>();
			RegisterMonoSystem<InventoryEvents>();
			
			// Overlay
			RegisterMonoSystem<ShopOverlayEvents>();
			RegisterMonoSystem<SoldierDetailOverlayEvents>();
			RegisterMonoSystem<SoldierListOverlayEvents>();
			RegisterMonoSystem<SummonOverlayEvents>();
			RegisterMonoSystem<WorldMapOverlayEvents>();
		}
	}

}