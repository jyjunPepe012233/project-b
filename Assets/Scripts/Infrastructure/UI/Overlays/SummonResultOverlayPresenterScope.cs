using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Lists;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.Dependency.VContainer.PresenterScope.Overlays
{

	public class SummonResultOverlayPresenterScope : BaseOverlayPresenterScope<SummonResultOverlayPresenter, SummonResultOverlayEvents>
	{
		[SerializeField] private PlayerSoldierCardListView _playerSoldierCardListView;
		[SerializeField] private PlayerSoldierCardView _soldierCardPrefab;
		[SerializeField] private ButtonView _summonAgainButtonView;

		[Inject] private SummonResultEvents _summonResultEvents;
		[Inject] private ISummonService _summonService;
		
		protected override SummonResultOverlayPresenter Compose()
		{
			return new SummonResultOverlayPresenter(_topElementView,
				_closeButtonView,
				_overlayEvents,
				_overlayStackService,
				_playerSoldierCardListView,
				_soldierCardPrefab,
				_summonAgainButtonView,
				_summonResultEvents,
				_summonService);
		}
	}

}