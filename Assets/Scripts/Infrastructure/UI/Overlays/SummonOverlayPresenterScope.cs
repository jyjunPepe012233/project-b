using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Buttons;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Overlays
{

	public class SummonOverlayPresenterScope : BaseOverlayPresenterScope<SummonOverlayPresenter, SummonOverlayEvents>
	{
		[SerializeField] private ButtonView _summon1XButtonView;
		[SerializeField] private ButtonView _summon10XButtonView;
		
		[Inject] private ISummonService _summonService;
		
		protected override SummonOverlayPresenter Compose()
		{
			return new SummonOverlayPresenter(_topElementView,
				_closeButtonView,
				_overlayEvents,
				_overlayStackService,
				_summon1XButtonView,
				_summon10XButtonView,
				_summonService);
		}
	}

}