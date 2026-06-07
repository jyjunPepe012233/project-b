using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Overlays
{

	public abstract class BaseOverlayPresenterScope<TPresenter, TOverlayEvents> : UIPresenterScope<TPresenter>
		where TPresenter : BaseOverlayPresenter<TOverlayEvents>
		where TOverlayEvents : class, IOverlayEvents
	{
		[SerializeField] protected TopElementView _topElementView;
		[SerializeField] protected ButtonView _closeButtonView;
		
		[Inject] protected TOverlayEvents _overlayEvents;
		[Inject] protected IOverlayStackService _overlayStackService;

		protected abstract override TPresenter Compose();
	}

}