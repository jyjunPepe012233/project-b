using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Presenters.PopUps;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.PopUps
{

	public class MenuPopUpPresenterScope : UIPresenterScope<MenuPopUpPresenter>
	{
		[SerializeField] private TopElementView _topElementView;
		[SerializeField] private ButtonView _closeButtonView;
		[SerializeField] private ButtonView _backpackButtonView;
		
		[Inject] private MenuEvents _menuEvents;
		[Inject] private IBackpackOverlayService _backpackOverlayService;
		
		protected override MenuPopUpPresenter Compose()
		{
			return new MenuPopUpPresenter(_topElementView,
				_closeButtonView,
				_backpackButtonView,
				_menuEvents,
				_backpackOverlayService);
		}
	}

}
