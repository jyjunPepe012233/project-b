using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;

namespace ProjectB.UI.Presenters.Overlays
{
	
	// Screen 단위의 Presenter들의 공통 기능을 제공하는 추상 클래스임.
	
	// topElementView와 제네릭으로 입력받은 TOverlayService, TOverlayEvents에 대한 의존성을 가지고 있으며,
	// 이벤트에 반응하여 topElementView의 Show/Hide를 제어하는 기능을 제공함.
	
	// + closeButton에 대한 의존성도 가지며, closeButtonView가 클릭되었을 때 TOverlayService의 Close()를 호출하는 기능도 제공함.
	
	public abstract class BaseOverlayPresenter<TOverlayEvents> : UIPresenter
		where TOverlayEvents : class, IOverlayEvents
	{
		protected readonly TopElementView topElementView;
		protected readonly ButtonView closeButtonView;
		
		protected readonly TOverlayEvents overlayEvents;
		protected readonly IOverlayStackService overlayStackService;
		
		protected BaseOverlayPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			TOverlayEvents overlayEvents,
			IOverlayStackService overlayStackService)
		{
			this.topElementView = topElementView;
			this.closeButtonView = closeButtonView;
			this.overlayEvents = overlayEvents;
			this.overlayStackService = overlayStackService;
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			closeButtonView.ButtonClicked += OnCloseButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			closeButtonView.ButtonClicked -= OnCloseButtonClicked;
		}
		
		protected virtual void OnCloseButtonClicked()
		{
			overlayStackService.CloseCurrentOverlay();
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			overlayEvents.Open += OnOpenScreen;
			overlayEvents.Close += OnCloseScreen;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			overlayEvents.Open -= OnOpenScreen;
			overlayEvents.Close -= OnCloseScreen;
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