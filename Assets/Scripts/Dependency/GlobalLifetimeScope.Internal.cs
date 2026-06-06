using ProjectB.Data.Static.Item;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Internal.Implements;
using ProjectB.Gameplay.Internal.Implements.Computer;
using ProjectB.Gameplay.Internal.Implements.Factory;
using ProjectB.Gameplay.Internal.Implements.Overlay;
using ProjectB.Gameplay.Internal.Implements.Screen;
using ProjectB.Gameplay.Internal.Ports;
using ProjectB.Gameplay.Internal.Ports.Computer;
using ProjectB.Gameplay.Internal.Ports.Factory;
using ProjectB.Gameplay.Internal.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Screen;

namespace ProjectB.Dependency
{

	public partial class GlobalLifetimeScope
	{
		void RegisterInternalSystems()
		{
			// Computer
			RegisterPortAdapter<ISoldierCombatPowerComputer, SoldierCombatPowerComputer>();
			RegisterPortAdapter<ISoldierStatusComputer, SoldierStatusComputer>();

			// Factory
			RegisterPortAdapter<IPlayerSoldierFactoryPort, PlayerSoldierFactory>();
			
			// Overlay
			RegisterPortAdapter<IOverlayManager, OverlayManager>();
			RegisterPortAdapter<IShopOverlayController, ShopOverlayController>();
			RegisterPortAdapter<ISoldierDetailOverlayController, SoldierDetailOverlayController>();
			RegisterPortAdapter<ISoldierListOverlayController, SoldierListOverlayController>();
			RegisterPortAdapter<ISummonOverlayController, SummonOverlayController>();
			RegisterPortAdapter<IWorldMapOverlayController, WorldMapOverlayController>();
			
			// Screen
			RegisterPortAdapter<IHomeScreenLoader, HomeScreenLoader>();
			RegisterPortAdapter<ITransitionScreenController, TransitionScreenController>();
			
			// 분류 X
			RegisterPortAdapter<IChangeScreenTransitionService, ChangeScreenTransitionService>();
			// Consumable Item Resolver들은 제네릭을 기반으로 구현됨
			RegisterPortAdapter<IConsumableItemResolver<IGainCurrencyItem>, GainCurrencyItemResolver>();
			RegisterPortAdapter<IInternalInventoryService, InternalInventoryService>();
			RegisterPortAdapter<IInternalPlayerLevelUpService, InternalPlayerLevelUpService>();
		}
	}

}