using System.Collections;
using ProjectB.Core.Supports;
using ProjectB.Gameplay.Events;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Screens;
using UnityEngine;
using UnityEngine.Playables;

namespace ProjectB.UI.Presenters.Screens
{

	public class TransitionScreenPresenter : UIPresenter
	{
		private readonly PlayableAsset _fadeInAsset;
		private readonly PlayableAsset _fadeOutAsset;
		private readonly TransitionScreenView _transitionScreenView;
			
		private readonly ChangeScreenTransitionEvents _changeScreenTransitionEvents;

		public TransitionScreenPresenter(PlayableAsset fadeInAsset, PlayableAsset fadeOutAsset, TransitionScreenView transitionScreenView, ChangeScreenTransitionEvents changeScreenTransitionEvents)
		{
			_fadeInAsset = fadeInAsset;
			_fadeOutAsset = fadeOutAsset;
			_transitionScreenView = transitionScreenView;
			_changeScreenTransitionEvents = changeScreenTransitionEvents;
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_changeScreenTransitionEvents.StartFadeIn += OnStartFadeIn;
			_changeScreenTransitionEvents.StartFadeOut += OnStartFadeOut;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_changeScreenTransitionEvents.StartFadeIn -= OnStartFadeIn;
			_changeScreenTransitionEvents.StartFadeOut -= OnStartFadeOut;
		}
		
		void OnStartFadeIn()
		{
			CoroutineHandler.StartAndAdd(FadeInRoutine());
		}

		IEnumerator FadeInRoutine()
		{
			yield return _transitionScreenView.PlayFadeIn(_fadeInAsset);
			_changeScreenTransitionEvents.FadeInComplete?.Invoke();
		}
		
		void OnStartFadeOut()
		{
			CoroutineHandler.StartAndAdd(FadeOutRoutine());
		}

		IEnumerator FadeOutRoutine()
		{
			yield return _transitionScreenView.PlayFadeOut(_fadeOutAsset);
			_changeScreenTransitionEvents.FadeOutComplete?.Invoke();
		}
	}

}