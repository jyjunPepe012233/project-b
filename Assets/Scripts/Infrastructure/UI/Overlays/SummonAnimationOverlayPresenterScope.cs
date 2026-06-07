using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Media;
using UnityEngine;
using UnityEngine.Playables;
using VContainer;

namespace ProjectB.Infrastructure.Dependency.VContainer.PresenterScope.Overlays
{

	public class SummonAnimationOverlayPresenterScope : BaseOverlayPresenterScope<SummonAnimationOverlayPresenter, SummonAnimationOverlayEvents>
	{
		[SerializeField] private SummonAnimationView _summonAnimationView;
		[SerializeField] private PlayableAsset _summonAnimationAsset;
		
		[Inject] private SummonAnimationEvents _summonAnimationEvents;
		
		protected override SummonAnimationOverlayPresenter Compose()
		{
			return new SummonAnimationOverlayPresenter(_topElementView,
				_closeButtonView,
				_overlayEvents,
				_overlayStackService,
				_summonAnimationView,
				_summonAnimationAsset,
				_summonAnimationEvents);
		}
	}

}