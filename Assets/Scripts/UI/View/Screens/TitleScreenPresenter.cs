using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.UI.Core;
using ProjectB.UI.View.Buttons;

namespace ProjectB.UI.View.Screens
{

	public class TitleScreenPresenter : UIPresenter
	{
		private readonly ButtonView _clickAreaView;
		private readonly ITitleScreenManagerPort _titleScreenManagerPort;

		public TitleScreenPresenter(ButtonView clickAreaView, ITitleScreenManagerPort titleScreenManagerPort)
		{
			_clickAreaView = clickAreaView;
			_titleScreenManagerPort = titleScreenManagerPort;
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
			_titleScreenManagerPort.Touched();
		}
	}

}