using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Presenters.Buttons;
using ProjectB.UI.Views.Buttons;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Buttons
{

	public class CloseAllOverlaysButtonPresenterScope : UIPresenterScope<CloseAllOverlaysButtonPresenter>
	{
		[SerializeField] private ButtonView _buttonView;

		[Inject] private IOverlayStackService _overlayStackService;

		protected override CloseAllOverlaysButtonPresenter Compose()
		{
			return new CloseAllOverlaysButtonPresenter(_buttonView, _overlayStackService);
		}
	}

}
