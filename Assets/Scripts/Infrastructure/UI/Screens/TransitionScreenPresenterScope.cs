using ProjectB.Gameplay.Events;
using ProjectB.UI.Presenters.Screens;
using ProjectB.UI.Views.Media;
using UnityEngine;
using UnityEngine.Playables;
using VContainer;

namespace ProjectB.Infrastructure.UI.Screens
{

	public class TransitionScreenPresenterScope : UIPresenterScope<TransitionScreenPresenter>
	{
		[SerializeField] private PlayableAsset _fadeInAsset;
		[SerializeField] private PlayableAsset _fadeOutAsset;
		[SerializeField] private PlayableView _playableView;
		
		[Inject] private ChangeScreenTransitionEvents _changeScreenTransitionEvents;
		
		protected override TransitionScreenPresenter Compose()
		{
			return new TransitionScreenPresenter(_fadeInAsset, _fadeOutAsset, _playableView, _changeScreenTransitionEvents);
		}
	}

}