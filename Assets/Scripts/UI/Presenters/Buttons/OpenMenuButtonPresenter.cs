using ProjectB.Gameplay.Events;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;

namespace ProjectB.UI.Presenters.Buttons
{

	public class OpenMenuButtonPresenter : UIPresenter
	{
		private readonly ButtonView _buttonView;
		private readonly MenuEvents _menuEvents;

		public OpenMenuButtonPresenter(ButtonView buttonView, MenuEvents menuEvents)
		{
			_buttonView = buttonView;
			_menuEvents = menuEvents;
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_buttonView.ButtonClicked += OnButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_buttonView.ButtonClicked -= OnButtonClicked;
		}

		void OnButtonClicked()
		{
			_menuEvents.Open?.Invoke();
		}
	}

}
