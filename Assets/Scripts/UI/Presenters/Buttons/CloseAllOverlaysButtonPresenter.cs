using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;

namespace ProjectB.UI.Presenters.Buttons
{

	public class CloseAllOverlaysButtonPresenter : UIPresenter
	{
		private readonly ButtonView _buttonView;
		private readonly IOverlayStackService _overlayStackService;

		public CloseAllOverlaysButtonPresenter(ButtonView buttonView, IOverlayStackService overlayStackService)
		{
			_buttonView = buttonView;
			_overlayStackService = overlayStackService;
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
			_overlayStackService.CloseAllOverlays();
		}
	}

}
