using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Lists;

namespace ProjectB.UI.Presenters.Overlays
{

	public class SoldierListOverlayPresenter : BaseOverlayPresenter<SoldierListOverlayEvents>
	{
		private readonly PlayerSoldierCardListView _soldierListView;
		private readonly IPlayerDataService _playerDataService;

		public SoldierListOverlayPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			SoldierListOverlayEvents overlayEvents,
			IOverlayStackService overlayStackService,
			PlayerSoldierCardListView soldierListView,
			IPlayerDataService playerDataService) : base(topElementView, closeButtonView, overlayEvents, overlayStackService)
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
			_soldierListView.ClearItems();
			
			foreach (var playerSoldier in _playerDataService.GetPlayerData().Soldiers)
			{
				var soldierCard = _soldierListView.CreateItem();

				var soldierData = playerSoldier.SoldierData; 
				soldierCard.SetSoldierName(soldierData.SoldierName);
				soldierCard.SetSoldierDisplay(soldierData.CardDisplaySetting.DisplayedSoldierPrefab);
				soldierCard.SetRoleIcon(soldierData.Role.IconPrefab64);
				soldierCard.SetSpiritIcon(soldierData.Spirit.IconPrefab64);
			}
		}
	}

}
