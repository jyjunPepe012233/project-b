using ProjectB.Authoring.ScriptableObject.Invasion;
using ProjectB.Authoring.ScriptableObject.Item;
using ProjectB.Authoring.ScriptableObject.Morale;
using ProjectB.Authoring.ScriptableObject.Soldier;
using ProjectB.Authoring.ScriptableObject.Summon;
using ProjectB.Authoring.ScriptableObject.Sweep;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Static.Morale;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Static.Summon;
using ProjectB.Data.Static.Sweep;
using ProjectB.Gameplay;
using ProjectB.Gameplay.Ports;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Infrastructure;
using UnityEngine;
using VContainer;

namespace ProjectB.Dependency.Scopes
{

	public class CoreLifetimeScope : StructuredLifetimeScope
	{
		[SerializeField] private SoldierDatabaseSO _soldierDatabaseSO;
		[SerializeField] private ItemDatabaseSO _itemDatabaseSO;
		[SerializeField] private InvasionSettingSO _invasionSettingSO;
		[SerializeField] private SummonCostSettingSO _summonCostSettingSo;
		[SerializeField] private MoraleSettingSO _moraleSettingSO;
		[SerializeField] private SweepSettingSO _sweepSettingSO;

		protected override void Awake()
		{
			base.Awake();
			
			Container.Resolve<PlayerSessionInitializer>();
			Container.Resolve<GlobalErrorHandler>();

			Container.Resolve<FirebaseInitializer>();
		}
		
		protected override void AddInboundAdapters()
		{
			base.AddInboundAdapters();
			Builder.Register<LoadingManager>(Lifetime.Singleton).As<
				ILoadingServicePort,
				ILoadingOverlayManagerPort
			>();

			RegisterPortAdapter<IPlayerDataServicePort, PlayerDataService>();

			// TODO:
			// PlayerSessionInitializer는 Inbound Adapter가 아니라 독립적으로 작동하는 게임 시스템에 가까움.
			// 이 사례처럼 클래스에 대한 분리 기준이 항상 명확하게 작용하지 않고 있으므로 StructureLifetimeScope를 리팩토링하여
			// 클래스 구분을 최대한 유연하게 만들거나 없애는 방안을 고려해볼 수 있음.
			// 지금은 임시로 Inbound Adapter를 등록하는 메서드에서 등록함
			// + 추가로, 이 클래스는 게임 실행 시 바로 생성되어야 하는 Entry Point이므로 Awake에서 Resolve함
			Builder.Register<PlayerSessionInitializer>(Lifetime.Singleton);
			
			// GlobalErrorHandler도 PlayerSessionInitializer와 같은 `Entry Point` 성격의 클래스임
			// 이것도 마찬가지로 임시로 Inbound Adapter 등록 메서드에서 등록
			Builder.Register<GlobalErrorHandler>(Lifetime.Singleton);
			
			
			// 사도 정보는 대부분의 화면에서 열릴 수 있기 때문에 Core에 등록
			RegisterPortAdapter<ISoldierDetailServicePort, SoldierDetailService>();
			
			// 플레이어가 보유한 아이템들의 정보는 인벤토리 화면 뿐만 아니라 다양한 화면에서 필요할 수 있기 때문에 Core에 등록 
			RegisterPortAdapter<IInventoryServicePort, InventoryService>();
			
			// 메뉴는 게임 내 거의 모든 화면에서 열릴 수 있기 때문에 Core에 등록
			// 사실 Home 화면에서만 열리긴 하는데, 이후 변경 가능성이 있으니까 Core에 등록
			RegisterPortAdapter<IMenuServicePort, MenuService>();

			RegisterPortAdapter<IRechargeMoraleServicePort, RechargeMoraleService>();
			RegisterPortAdapter<ISweepService, SweepService>();
			RegisterPortAdapter<ISoldierEquipServicePort, SoldierEquipService>();
		}

		protected override void AddInternalAdapters()
		{
			base.AddInternalAdapters();
			RegisterPortAdapter<ISoldierStatusComputerPort, SoldierStatusComputer>();
			RegisterPortAdapter<ISoldierCombatPowerComputerPort, SoldierCombatPowerComputer>();
			RegisterPortAdapter<IPlayerSoldierFactory, PlayerSoldierFactory>();
			RegisterPortAdapter<IInternalInventoryServicePort, InternalInventoryService>();
		}

		protected override void AddOutboundAdapters()
		{
			base.AddOutboundAdapters();
			RegisterPortAdapter<IControlLoadingOverlayPort, ControlLoadingOverlayService>();
			RegisterPortAdapter<ILoadHomePort, LoadHomeService>();
			RegisterPortAdapter<IPlayerSessionHolderPort, PlayerSessionHolderService>();
			RegisterPortAdapter<ILoadPlayerDataPort, LoadPlayerDataService>();
			RegisterPortAdapter<IInitializePlayerSessionPort, InitializePlayerSessionService>();
			RegisterPortAdapter<ILoadSoldierDetailScreenPort, LoadSoldierDetailScreenService>();
			RegisterPortAdapter<ILoadRewardGainPopupPort, LoadRewardGainPopupPort>();
			RegisterPortAdapter<IUncaughtErrorCatcherPort, UncaughtErrorCatcherService>();
			RegisterPortAdapter<IReportErrorPort, ReportErrorService>();
			RegisterPortAdapter<ILoadBackpackScreenPort, LoadBackpackScreenService>();
			
			// 사실 Outbound Port 보다는 Infrastructure 내부의 특정 기술 사용을 위한 독립적 클래스임
			// 지금은 임시로 Outbound Adapter 등록 메서드에서 등록
			// + Awake에서 Resolve함 (게임 시작 시 바로 생성되어야 하므로)
			Builder.Register<FirebaseInitializer>(Lifetime.Singleton);
		}

		protected override void AddData()
		{
			base.AddData();
			RegisterPortInstance<IInvasionSetting, InvasionSettingSO>(_invasionSettingSO);
			RegisterPortInstance<ISoldierDatabase, SoldierDatabaseSO>(_soldierDatabaseSO);
			RegisterPortInstance<IItemDatabase, ItemDatabaseSO>(_itemDatabaseSO);
			RegisterPortInstance<ISummonCostSetting, SummonCostSettingSO>(_summonCostSettingSo);
			RegisterPortInstance<IMoraleSetting, MoraleSettingSO>(_moraleSettingSO);
			RegisterPortInstance<ISweepSetting, SweepSettingSO>(_sweepSettingSO);
		}
	}

}