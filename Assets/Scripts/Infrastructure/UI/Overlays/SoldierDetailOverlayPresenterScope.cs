using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Soldier;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Pages.SoldierDetail;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Overlays
{

	public class SoldierDetailOverlayPresenterScope : BaseOverlayPresenterScope<SoldierDetailOverlayPresenter, SoldierDetailOverlayEvents>
	{
		[SerializeField] private SoldierDetailInfoPageView _infoPageView;
		[SerializeField] private SoldierDetailLevelUpPageView _levelUpPageView;
		
		[Inject] private SoldierDetailEvents _soldierDetailEvents;
		[Inject] private ISoldierLevelUpService _soldierLevelUpService;
		
		protected override SoldierDetailOverlayPresenter Compose()
		{
			return new SoldierDetailOverlayPresenter(_topElementView,
				_closeButtonView,
				_overlayEvents,
				_overlayStackService,
				_infoPageView,
				_levelUpPageView,
				_soldierDetailEvents,
				_soldierLevelUpService);
		}
	}

}