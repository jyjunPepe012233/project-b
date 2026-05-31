using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.UI.Core;
using ProjectB.UI.View.Buttons;
using ProjectB.UI.View.Common;

namespace ProjectB.UI.Presenters.Screens
{
	
	// Screen 단위의 Presenter들의 공통 기능을 제공하는 추상 클래스임.
	
	// topElementView와 제네릭으로 입력받은 TScreenService에 대한 의존성을 가지고 있으며,
	// TScreenService의 Open/Close 이벤트에 반응하여 topElementView의 Show/Hide를 수행하는 기능을 제공함.
	
	// + closeButton에 대한 의존성도 가지며, closeButton이 클릭되었을 때 TScreenService의 Close()를 호출하는 기능도 제공함.
	
	public abstract class BaseScreenPresenter<TScreenService> : UIPresenter where TScreenService : IBaseScreenService
	{
		protected readonly TopElementView topElementView;
		protected readonly ButtonView closeButton;
		
		protected readonly TScreenService screenService;
		
		protected BaseScreenPresenter(TopElementView topElementView,
			ButtonView closeButton,
			TScreenService screenService)
		{
			this.topElementView = topElementView;
			this.closeButton = closeButton;
			this.screenService = screenService;
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			closeButton.ButtonClicked += OnCloseButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			closeButton.ButtonClicked -= OnCloseButtonClicked;
		}
		
		protected virtual void OnCloseButtonClicked()
		{
			screenService.Close();
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			screenService.Events.Open += OnOpenScreen;
			screenService.Events.Close += OnCloseScreen;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			screenService.Events.Open -= OnOpenScreen;
			screenService.Events.Close -= OnCloseScreen;
		}
		
		protected virtual void OnOpenScreen()
		{
			topElementView.Show();
		}
		
		protected virtual void OnCloseScreen()
		{
			topElementView.Hide();
		}
	}

}