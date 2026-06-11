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
			RegisterMonoSystem<MenuEvents>();
			RegisterMonoSystem<SoldierDetailEvents>();
			RegisterMonoSystem<SoldierInfoEvents>();
			RegisterMonoSystem<StageInfoEvents>();
			RegisterMonoSystem<SummonAnimationEvents>();
			RegisterMonoSystem<SummonResultEvents>();
			
			// Overlay
			RegisterMonoSystem<BackpackOverlayEvents>();
			RegisterMonoSystem<ShopOverlayEvents>();
			RegisterMonoSystem<SoldierDetailOverlayEvents>();
			RegisterMonoSystem<SoldierListOverlayEvents>();
			RegisterMonoSystem<SummonOverlayEvents>();
			RegisterMonoSystem<SummonAnimationOverlayEvents>();
			RegisterMonoSystem<SummonResultOverlayEvents>();
			RegisterMonoSystem<WorldMapOverlayEvents>();
		}
	}

}
