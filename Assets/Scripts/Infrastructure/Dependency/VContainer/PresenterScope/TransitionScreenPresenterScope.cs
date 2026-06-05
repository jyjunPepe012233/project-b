using ProjectB.Gameplay.Events;
using ProjectB.UI.Presenters.Screens;
using ProjectB.UI.Views.Screens;
using UnityEngine;
using UnityEngine.Playables;
using VContainer;

namespace ProjectB.Infrastructure.Dependency.VContainer.PresenterScope
{

	public class TransitionScreenPresenterScope : UIPresenterScope<TransitionScreenPresenter>
	{
		[SerializeField] private PlayableAsset _fadeInAsset;
		[SerializeField] private PlayableAsset _fadeOutAsset;
		[SerializeField] private TransitionScreenView _transitionScreenView;
		
		[Inject] private ChangeScreenTransitionEvents _changeScreenTransitionEvents;
		
		protected override TransitionScreenPresenter Compose()
		{
			return new TransitionScreenPresenter(_fadeInAsset, _fadeOutAsset, _transitionScreenView, _changeScreenTransitionEvents);
		}
	}

}