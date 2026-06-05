using ProjectB.Gameplay.Inbound.Ports.Screen;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;

namespace ProjectB.UI.Presenters.Screens
{
	
	public class TitleScreenPresenter : UIPresenter
	{
		private readonly ButtonView _clickAreaView;
		private readonly ITitleScreenManager _titleScreenManager;

		public TitleScreenPresenter(ButtonView clickAreaView, ITitleScreenManager titleScreenManager)
		{
			_clickAreaView = clickAreaView;
			_titleScreenManager = titleScreenManager;
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_clickAreaView.ButtonClicked += OnClickAreaClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_clickAreaView.ButtonClicked -= OnClickAreaClicked;
		}

		void OnClickAreaClicked()
		{
			_titleScreenManager.Touched();
		}
	}

}