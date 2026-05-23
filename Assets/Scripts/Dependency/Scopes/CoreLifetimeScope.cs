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
using ProjectB.Gameplay.Ports;
using ProjectB.Gameplay.Ports.Inbound;
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
			
			Container.Resolve<PlayerSessionInitializer>();
			Container.Resolve<GlobalErrorHandler>();
			Container.Resolve<FirebaseInitializer>();
			Container.Resolve<GameFrameSetup>();
		}


		protected sealed override void Configure(IContainerBuilder builder)
		{
			_builder = builder;
			
			
			// 데이터 등록
			RegisterPortInstance<IInvasionSetting, InvasionSettingSO>(_invasionSettingSO);
			RegisterPortInstance<ISoldierDatabase, SoldierDatabaseSO>(_soldierDatabaseSO);
			RegisterPortInstance<IItemDatabase, ItemDatabaseSO>(_itemDatabaseSO);
			RegisterPortInstance<ISummonCostSetting, SummonCostSettingSO>(_summonCostSettingSo);
			RegisterPortInstance<IMoraleSetting, MoraleSettingSO>(_moraleSettingSO);
			RegisterPortInstance<ISweepSetting, SweepSettingSO>(_sweepSettingSO);
			RegisterPortInstance<IPlayerLevelUpSetting, PlayerLevelUpSettingSO>(_playerLevelUpSettingSO);
			RegisterPortInstance<IGlobalSoldierLevelUpSetting, GlobalSoldierLevelUpSettingSO>(_globalSoldierLevelUpSettingSO);
			
			
			
			// Initializer 등록
			builder.Register<PlayerSessionInitializer>(Lifetime.Singleton);
			builder.Register<GlobalErrorHandler>(Lifetime.Singleton);
			builder.Register<FirebaseInitializer>(Lifetime.Singleton);
			builder.Register<GameFrameSetup>(Lifetime.Singleton);
			
			// 이 클래스들은 게임 시작 시 바로 작동을 시작해야 하는 Entry Point이므로 직접 Resolve함
			Container.Resolve<PlayerSessionInitializer>();
			Container.Resolve<GlobalErrorHandler>();
			Container.Resolve<FirebaseInitializer>();
			Container.Resolve<GameFrameSetup>();

			
			
			// Inbound Port 어댑터 등록
			RegisterPortAdapter<ITitleScreenManagerPort, TitleScreenManager>();
			builder.Register<LoadingManager>(Lifetime.Singleton).As<ILoadingServicePort, ILoadingOverlayManagerPort>();
			RegisterPortAdapter<IHomeScreenManagerPort, HomeScreenManager>();
			RegisterPortAdapter<IPlayerDataServicePort, PlayerDataService>();
			RegisterPortAdapter<ISoldierDetailServicePort, SoldierDetailService>();
			RegisterPortAdapter<IInventoryServicePort, InventoryService>();
			RegisterPortAdapter<IRechargeMoraleServicePort, RechargeMoraleService>();
			RegisterPortAdapter<ISweepService, SweepService>();
			RegisterPortAdapter<ISoldierEquipServicePort, SoldierEquipService>();
			RegisterPortAdapter<ICraftEquipmentServicePort, CraftEquipmentService>();
			RegisterPortAdapter<IShopServicePort, ShopService>();
			builder.Register<SummonManager>(Lifetime.Singleton).As<ISummonServicePort, ISummonAnimationManagerPort>();
			RegisterPortAdapter<ILoadSummonScreenPort, LoadSummonScreenService>();
			RegisterPortAdapter<ILoadSummonAnimationScreenPort, LoadSummonAnimationScreenService>();
			RegisterPortAdapter<ILoadSummonResultScreenPort, LoadSummonResultScreenService>();
			
			
			
			// Internal Port 어댑터 등록
			RegisterPortAdapter<ISoldierStatusComputerPort, SoldierStatusComputer>();
			RegisterPortAdapter<ISoldierCombatPowerComputerPort, SoldierCombatPowerComputer>();
			RegisterPortAdapter<IPlayerSoldierFactoryPort, PlayerSoldierFactory>();
			RegisterPortAdapter<IInternalInventoryServicePort, InternalInventoryService>();
			RegisterPortAdapter<IInternalPlayerLevelUpServicePort, InternalPlayerLevelUpService>();
			
			// ConsumableItemResolver들은 제네릭으로 관리되며, 주입받을 때도 제네릭 타입으로 종류를 구분하면 됨
			RegisterPortAdapter<IConsumableItemResolverPort<IGainCurrencyItem>, GainCurrencyItemResolver>();
			
			
			
			// Outbound Port 어댑터 등록
			RegisterPortAdapter<ILoadSummonScreenPort, LoadSummonScreenService>();
			RegisterPortAdapter<IUnloadScreenPort, UnloadScreenService>();
			RegisterPortAdapter<ILoadLoadingOverlayServicePort, LoadLoadingOverlayServiceService>();
			RegisterPortAdapter<ILoadHomePort, LoadHomeService>();
			RegisterPortAdapter<IPlayerSessionHolderPort, PlayerSessionHolderService>();
			RegisterPortAdapter<ILoadPlayerDataPort, LoadPlayerDataService>();
			RegisterPortAdapter<IInitializePlayerSessionPort, InitializePlayerSessionService>();
			RegisterPortAdapter<ILoadSoldierDetailScreenPort, LoadSoldierDetailScreenService>();
			RegisterPortAdapter<ILoadRewardGainPopupPort, LoadRewardGainPopupPort>();
			RegisterPortAdapter<IUncaughtErrorCatcherPort, UncaughtErrorCatcherService>();
			RegisterPortAdapter<IReportErrorPort, ReportErrorService>();
			RegisterPortAdapter<ILoadBackpackScreenPort, LoadBackpackScreenService>();
		}
	}

}