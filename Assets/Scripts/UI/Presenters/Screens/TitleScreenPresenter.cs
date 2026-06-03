using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;

namespace ProjectB.UI.Presenters.Screens
{

	// TitleScreenPresenter는 BaseScreenPresenter를 상속받지 않음
	// BaseScreenPresenter는 화면 열기/닫기 중심의 기능을 제공하는데,
	// 타이틀 화면은 게임 시작 시 자동으로 열리고 다시 열리지 않으므로 BaseScreenPresenter의 기능이 필요하지 않음.
	
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