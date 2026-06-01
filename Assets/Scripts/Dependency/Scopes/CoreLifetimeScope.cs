using ProjectB.Authoring.ScriptableObject.Invasion;
using ProjectB.Authoring.ScriptableObject.Item;
using ProjectB.Authoring.ScriptableObject.Morale;
using ProjectB.Authoring.ScriptableObject.Player;
using ProjectB.Authoring.ScriptableObject.Soldier;
using ProjectB.Authoring.ScriptableObject.Summon;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Static.Morale;
using ProjectB.Data.Static.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Static.Summon;
using ProjectB.Gameplay;
using ProjectB.Gameplay.Implements.Inbound.Screen;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Infrastructure;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectB.Dependency.Scopes
{

	public sealed class CoreLifetimeScope : LifetimeScope
	{
		private IContainerBuilder _builder;

		[SerializeField] private SoldierDatabaseSO _soldierDatabaseSO;
		[SerializeField] private ItemDatabaseSO _itemDatabaseSO;
		[SerializeField] private InvasionSettingSO _invasionSettingSO;
		[SerializeField] private SummonCostSettingSO _summonCostSettingSo;
		[SerializeField] private MoraleSettingSO _moraleSettingSO;
		[SerializeField] private SweepSettingSO _sweepSettingSO;
		[SerializeField] private PlayerLevelUpSettingSO _playerLevelUpSettingSO;
		[SerializeField] private GlobalSoldierLevelUpSettingSO _globalSoldierLevelUpSettingSO;
		
		
		void RegisterPortAdapter<TPort, TAdapter>()
			where TPort : class
			where TAdapter : class, TPort
		{
			_builder.Register<TAdapter>(Lifetime.Singleton).As<TPort>();
		}
		
		
		void RegisterPortInstance<TPort, TAdapter>(TAdapter instance)
			where TPort : class
			where TAdapter : class, TPort
		{
			_builder.RegisterInstance(instance).As<TPort>();
		}
		
		
		protected override void Awake()
		{
			base.Awake();
			
			// base.Awake() 후에(= Configure 후) Resolve해야함.
			Container.Resolve<PlayerSessionInitializer>();
			Container.Resolve<GlobalErrorHandler>();
			Container.Resolve<FirebaseInitializer>();
			Container.Resolve<GameFrameSetup>();
		}


		protected sealed override void Configure(IContainerBuilder builder)
		{
			_builder = builder;

			// ==============================================================
			// Initializer 등록
			// 어셈블리, 포트 종류 등과 무관하게 Awake 시점부터 필요한 객체들을 등록
			// 이 클래스들은 Awake 시점에서 Resolve됨.
			// ==============================================================
			
			builder.Register<PlayerSessionInitializer>(Lifetime.Singleton);
			builder.Register<GlobalErrorHandler>(Lifetime.Singleton);
			builder.Register<FirebaseInitializer>(Lifetime.Singleton);
			builder.Register<GameFrameSetup>(Lifetime.Singleton);
			
			
			// ==============================================================
			// 데이터 인스턴스 등록
			// ==============================================================
			
			RegisterPortInstance<IInvasionSetting, InvasionSettingSO>(_invasionSettingSO);
			RegisterPortInstance<ISoldierDatabase, SoldierDatabaseSO>(_soldierDatabaseSO);
			RegisterPortInstance<IItemDatabase, ItemDatabaseSO>(_itemDatabaseSO);
			RegisterPortInstance<ISummonCostSetting, SummonCostSettingSO>(_summonCostSettingSo);
			RegisterPortInstance<IMoraleSetting, MoraleSettingSO>(_moraleSettingSO);
			RegisterPortInstance<ISweepSetting, SweepSettingSO>(_sweepSettingSO);
			RegisterPortInstance<IPlayerLevelUpSetting, PlayerLevelUpSettingSO>(_playerLevelUpSettingSO);
			RegisterPortInstance<IGlobalSoldierLevelUpSetting, GlobalSoldierLevelUpSettingSO>(_globalSoldierLevelUpSettingSO);
			

			// ==============================================================
			// Inbound Port 어댑터 등록
			// ==============================================================
			
			// - Player
			RegisterPortAdapter<IPlayerDataServicePort, PlayerDataService>();

			// - Soldier
			RegisterPortAdapter<ISoldierDetailServicePort, SoldierDetailService>();
			RegisterPortAdapter<ISoldierEquipServicePort, SoldierEquipService>();
			RegisterPortAdapter<ICraftEquipmentServicePort, CraftEquipmentService>();
			RegisterPortAdapter<ISoldierLevelUpServicePort, SoldierLevelUpService>();

			// - Inventory
			RegisterPortAdapter<IInventoryServicePort, InventoryService>();
			RegisterPortAdapter<IConsumeItemServicePort, ConsumeItemService>();
			
			// - Screen
			RegisterPortAdapter<ITitleScreenManager, TitleScreenManager>();
			RegisterPortAdapter<ISummonScreenService, SummonScreenService>();
			RegisterPortAdapter<IShopScreenService, ShopScreenService>();
			RegisterPortAdapter<ISoldierListScreenService, SoldierListScreenService>();
			RegisterPortAdapter<IWorldMapScreenService, WorldMapScreenService>();
			
			// - 분류 X
			RegisterPortAdapter<IRechargeMoraleServicePort, RechargeMoraleService>();
			RegisterPortAdapter<ISweepService, SweepService>();
			RegisterPortAdapter<IShopServicePort, ShopService>();
			RegisterPortAdapter<IMenuServicePort, MenuService>();
			builder.Register<SummonManager>(Lifetime.Singleton).As<ISummonServicePort, ISummonAnimationManagerPort>();
			
			
			// ==============================================================
			// Internal Port 어댑터 등록
			// ==============================================================

			// - Computer
			RegisterPortAdapter<ISoldierStatusComputerPort, SoldierStatusComputer>();
			RegisterPortAdapter<ISoldierCombatPowerComputerPort, SoldierCombatPowerComputer>();

			// - Factory
			RegisterPortAdapter<IPlayerSoldierFactoryPort, PlayerSoldierFactory>();
			
			// - 분류 X
			RegisterPortAdapter<ILoadingTransitionServicePort , LoadingTransitionService>();
			RegisterPortAdapter<IInternalInventoryServicePort, InternalInventoryService>();
			RegisterPortAdapter<IInternalPlayerLevelUpServicePort, InternalPlayerLevelUpService>();
			RegisterPortAdapter<IConsumableItemResolverPort<IGainCurrencyItem>, GainCurrencyItemResolver>();
			
			
			// ==============================================================
			// Outbound Port 어댑터 등록
			// ==============================================================

			// - Player
			RegisterPortAdapter<IPlayerSessionHolderPort, PlayerSessionHolderService>();
			RegisterPortAdapter<ILoadPlayerDataPort, LoadPlayerDataService>();
			RegisterPortAdapter<IInitializePlayerSessionPort, InitializePlayerSessionService>();

			// - Error
			RegisterPortAdapter<IUncaughtErrorCatcherPort, UncaughtErrorCatcherService>();
			RegisterPortAdapter<IReportErrorPort, ReportErrorService>();
		}
	}

}
