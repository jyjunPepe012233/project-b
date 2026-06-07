using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Presenters.Buttons;
using ProjectB.UI.Views.Buttons;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Buttons.OpenOverlayButton
{

	public abstract class OpenOverlayButtonPresenterScope<TOverlayService> : UIPresenterScope<OpenOverlayButtonPresenter<TOverlayService>> where TOverlayService : class, IOverlayService
	{
		[SerializeField] private ButtonView _buttonView;
		
		[Inject] private TOverlayService _overlayService;
		
		protected override OpenOverlayButtonPresenter<TOverlayService> Compose()
		{
			return new OpenOverlayButtonPresenter<TOverlayService>(_buttonView, _overlayService);
		}
	}

}