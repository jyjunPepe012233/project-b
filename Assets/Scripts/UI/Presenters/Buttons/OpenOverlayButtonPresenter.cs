using ProjectB.Gameplay.Ports.Inbound.Overlay;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;

namespace ProjectB.UI.Presenters.Buttons
{

	public class OpenOverlayButtonPresenter<TOverlayService> : UIPresenter where TOverlayService : class, IOverlayService
	{
		private readonly ButtonView _buttonView;
		private readonly TOverlayService _overlayService;

		public OpenOverlayButtonPresenter(ButtonView buttonView, TOverlayService overlayService)
		{
			_buttonView = buttonView;
			_overlayService = overlayService;
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
			_overlayService.Open();
		}
	}

}