using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Ports.Inbound.Overlay;
using ProjectB.Gameplay.Ports.Inbound.Player;
using ProjectB.UI.Presenters.Screens;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Lists;

namespace ProjectB.UI.Presenters.Overlays
{

	public class SoldierListOverlayPresenter : BaseOverlayPresenter<ISoldierListOverlayService, SoldierListOverlayEvents>
	{
		private readonly PlayerSoldierCardListView _soldierListView;
		private readonly IPlayerDataService _playerDataService;

		public SoldierListOverlayPresenter(TopElementView topElementView,
			ButtonView closeButton,
			ISoldierListOverlayService overlayService,
			SoldierListOverlayEvents overlayEvents,
			PlayerSoldierCardListView soldierListView,
			IPlayerDataService playerDataService) : base(topElementView, closeButton, overlayService, overlayEvents)
		{
			_soldierListView = soldierListView;
			_playerDataService = playerDataService;
		}

		protected override void OnOpenScreen()
		{
			base.OnOpenScreen();
			InitializeSoldierList();
		}

		// Soldier List 초기화 과정을 override하는 클래스가 생길 것을 고려하여 virtual로 선언함
		protected virtual void InitializeSoldierList()
		{
			_soldierListView.ClearCards();
			
			foreach (var playerSoldier in _playerDataService.GetPlayerData().Soldiers)
			{
				var soldierCard = _soldierListView.CreateCard();

				var soldierData = playerSoldier.SoldierData; 
				soldierCard.SetSoldierName(soldierData.SoldierName);
				soldierCard.SetSoldierDisplay(soldierData.CardDisplaySetting.DisplayedSoldierPrefab);
				soldierCard.SetRoleIcon(soldierData.Role.IconPrefab64);
				soldierCard.SetSpiritIcon(soldierData.Spirit.IconPrefab64);
			}
		}
	}

}
