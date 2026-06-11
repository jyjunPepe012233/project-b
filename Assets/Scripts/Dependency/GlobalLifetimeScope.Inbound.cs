using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Inbound.Implements;
using ProjectB.Gameplay.Inbound.Implements.Inventory;
using ProjectB.Gameplay.Inbound.Implements.Overlay;
using ProjectB.Gameplay.Inbound.Implements.Player;
using ProjectB.Gameplay.Inbound.Implements.Screen;
using ProjectB.Gameplay.Inbound.Implements.Soldier;
using ProjectB.Gameplay.Inbound.Ports;
using ProjectB.Gameplay.Inbound.Ports.Inventory;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.Gameplay.Inbound.Ports.Screen;
using ProjectB.Gameplay.Inbound.Ports.Soldier;
using VContainer;

namespace ProjectB.Dependency
{

	public partial class GlobalLifetimeScope
	{
		void RegisterInboundSystems()
		{
			// Inventory
			RegisterPortAdapter<IConsumeItemService, ConsumeItemService>();
			RegisterPortAdapter<ICraftEquipmentService, CraftEquipmentService>();
			RegisterPortAdapter<IInventoryService, InventoryService>();
			
			// Overlay
			RegisterPortAdapter<IOverlayStackService, OverlayStackService>();
			RegisterPortAdapter<IBackpackOverlayService, BackpackOverlayService>();
			RegisterPortAdapter<IPlayerInfoOverlayService, PlayerInfoOverlayService>();
			RegisterPortAdapter<IShopOverlayService, ShopOverlayService>();
			RegisterPortAdapter<ISoldierListOverlayService, SoldierListOverlayService>();
			RegisterPortAdapter<ISummonOverlayService, SummonOverlayService>();
			RegisterPortAdapter<IWorldMapOverlayService, WorldMapOverlayService>();
			
			// Player
			RegisterPortAdapter<IPlayerDataService, PlayerDataService>();
			
			// Screen
			RegisterPortAdapter<ITitleScreenManager, TitleScreenManager>();
			
			// Soldier
			RegisterPortAdapter<ISoldierDetailService, SoldierDetailService>();
			RegisterPortAdapter<ISoldierEquipService, SoldierEquipService>();
			RegisterPortAdapter<ISoldierLevelUpService, SoldierLevelUpService>();
			
			// 분류 X
			RegisterPortAdapter<IRechargeMoraleService, RechargeMoraleService>();
			RegisterPortAdapter<IShopService, ShopService>();
			RegisterPortAdapter<ISummonService, SummonService>();
			RegisterPortAdapter<ISweepService, SweepService>();
		}
	}

}
