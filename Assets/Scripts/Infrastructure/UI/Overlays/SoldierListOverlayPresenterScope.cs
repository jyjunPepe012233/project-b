using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Lists;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Overlays
{

	public class SoldierListOverlayPresenterScope : BaseOverlayPresenterScope<SoldierListOverlayPresenter, SoldierListOverlayEvents>
	{
		[SerializeField] private PlayerSoldierCardListView _soldierCardListView;
		[SerializeField] private PlayerSoldierCardView _soldierCardPrefab;
		
		[Inject] private IPlayerDataService _playerDataService; 
		
		protected override SoldierListOverlayPresenter Compose()
		{
			return new SoldierListOverlayPresenter(_topElementView,
				_closeButtonView,
				_overlayEvents,
				_overlayStackService,
				_soldierCardListView,
				_soldierCardPrefab,
				_playerDataService);
		}
	}

}