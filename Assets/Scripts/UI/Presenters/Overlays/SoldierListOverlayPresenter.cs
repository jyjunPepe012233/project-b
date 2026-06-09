using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.Gameplay.Inbound.Ports.Soldier;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Lists;

namespace ProjectB.UI.Presenters.Overlays
{

	public class SoldierListOverlayPresenter : BaseOverlayPresenter<SoldierListOverlayEvents>
	{
		private readonly PlayerSoldierCardListView _soldierCardListView;
		private readonly PlayerSoldierCardView _soldierCardView;
		
		private readonly IPlayerDataService _playerDataService;
		private readonly ISoldierDetailService _soldierDetailService;

		public SoldierListOverlayPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			SoldierListOverlayEvents overlayEvents,
			IOverlayStackService overlayStackService,
			PlayerSoldierCardListView soldierCardListView,
			PlayerSoldierCardView soldierCardView,
			IPlayerDataService playerDataService,
			ISoldierDetailService soldierDetailService) : base(topElementView, closeButtonView, overlayEvents, overlayStackService)
		{
			_soldierCardListView = soldierCardListView;
			_soldierCardView = soldierCardView;
			_playerDataService = playerDataService;
			_soldierDetailService = soldierDetailService;
		}

		public override void Initialize()
		{
			base.Initialize();
			_soldierCardListView.Initialize(_soldierCardView, 10);
		}

		protected override void OnOpenScreen()
		{
			base.OnOpenScreen();
			InitializeSoldierList();
		}

		// Soldier List 초기화 과정을 override하는 클래스가 생길 것을 고려하여 virtual로 선언함
		protected virtual void InitializeSoldierList()
		{
			_soldierCardListView.ClearItems();
			
			foreach (var playerSoldier in _playerDataService.GetPlayerData().Soldiers)
			{
				var soldierCard = _soldierCardListView.CreateItem();

				var soldierData = playerSoldier.SoldierData; 
				soldierCard.SetSoldierName(soldierData.SoldierName);
				soldierCard.SetSoldierDisplay(soldierData.CardDisplaySetting.DisplayedSoldierPrefab);
				soldierCard.SetRoleIcon(soldierData.Role.IconPrefab64);
				soldierCard.SetSpiritIcon(soldierData.Spirit.IconPrefab64);

				soldierCard.ButtonClicked += () => OnSoldierCardButtonClicked(playerSoldier);
			}
		}

		void OnSoldierCardButtonClicked(IReadOnlyPlayerSoldier playerSoldier)
		{
			_soldierDetailService.ShowSoldierDetail(playerSoldier.SoldierData);
		}
	}

}
