using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Soldier;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Misc;
using ProjectB.UI.Views.Pages.SoldierDetail;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Overlays
{

	public class SoldierDetailOverlayPresenterScope : BaseOverlayPresenterScope<SoldierDetailOverlayPresenter, SoldierDetailOverlayEvents>
	{
		[SerializeField] private TextView _soldierNameView;
		[SerializeField] private SoldierBasicInfoBarView _basicInfoBarView;

		[SerializeField] private ButtonView _infoPageButtonView;
		[SerializeField] private ButtonView _levelUpPageButtonView;
		
		[SerializeField] private SoldierDetailInfoPageView _infoPageView;
		[SerializeField] private SoldierDetailLevelUpPageView _levelUpPageView;
		
		[Inject] private SoldierDetailEvents _soldierDetailEvents;
		[Inject] private SoldierInfoEvents _soldierInfoEvents;
		[Inject] private ISoldierLevelUpService _soldierLevelUpService;
		
		protected override SoldierDetailOverlayPresenter Compose()
		{
			return new SoldierDetailOverlayPresenter(_topElementView,
				_closeButtonView,
				_overlayEvents,
				_overlayStackService,
				_soldierNameView,
				_basicInfoBarView,
				_infoPageButtonView,
				_levelUpPageButtonView,
				_infoPageView,
				_levelUpPageView,
				_soldierDetailEvents,
				_soldierInfoEvents,
				_soldierLevelUpService);
		}
	}

}
