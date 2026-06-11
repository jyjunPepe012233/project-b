using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;

namespace ProjectB.UI.Presenters.PopUps
{

	public class MenuPopUpPresenter : UIPresenter
	{
		private readonly TopElementView _topElementView;
		private readonly ButtonView _closeButtonView;
		private readonly ButtonView _backpackButtonView;
		
		private readonly MenuEvents _menuEvents;
		private readonly IBackpackOverlayService _backpackOverlayService;

		public MenuPopUpPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			ButtonView backpackButtonView,
			MenuEvents menuEvents,
			IBackpackOverlayService backpackOverlayService)
		{
			_topElementView = topElementView;
			_closeButtonView = closeButtonView;
			_backpackButtonView = backpackButtonView;
			_menuEvents = menuEvents;
			_backpackOverlayService = backpackOverlayService;
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_closeButtonView.ButtonClicked += OnCloseButtonClicked;
			_backpackButtonView.ButtonClicked += OnBackpackButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_closeButtonView.ButtonClicked -= OnCloseButtonClicked;
			_backpackButtonView.ButtonClicked -= OnBackpackButtonClicked;
		}

		void OnCloseButtonClicked()
		{
			_menuEvents.Close?.Invoke();
		}

		void OnBackpackButtonClicked()
		{
			_menuEvents.Close?.Invoke();
			_backpackOverlayService.Open();
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_menuEvents.Open += OnOpenMenu;
			_menuEvents.Close += OnCloseMenu;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_menuEvents.Open -= OnOpenMenu;
			_menuEvents.Close -= OnCloseMenu;
		}

		void OnOpenMenu()
		{
			_topElementView.Show(includeDefaultDisable: true);
		}

		void OnCloseMenu()
		{
			_topElementView.Hide();
		}
	}

}
