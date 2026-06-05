using System;
using System.Collections;
using ProjectB.Core.Supports;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Internal.Ports;
using ProjectB.Gameplay.Internal.Ports.Screen;
using UnityEngine;

namespace ProjectB.Gameplay.Internal.Implements
{

	public class ChangeScreenTransitionService : IChangeScreenTransitionService
	{
		private readonly ChangeScreenTransitionEvents _changeScreenTransitionEvents;
		private readonly ITransitionScreenController _transitionScreenController;

		private bool _isLoading = false;

		public ChangeScreenTransitionService(ChangeScreenTransitionEvents changeScreenTransitionEvents, ITransitionScreenController transitionScreenController)
		{
			_changeScreenTransitionEvents = changeScreenTransitionEvents;
			_transitionScreenController = transitionScreenController;
		}

		public void ChangeScreenWithTransition(Func<IEnumerator> changeScreenAction)
		{
			CoroutineHandler.StartAndAdd(ChangeScreenWithTransitionInternal(changeScreenAction));
		}
		
		IEnumerator ChangeScreenWithTransitionInternal(Func<IEnumerator> changeScreenAction)
		{
			if (_isLoading)
			{
				Debug.LogError("ChangeScreenTransitionService: 이미 로딩이 진행 중인데 다시 로딩이 시도됨");
				yield break;
			}
			
			_isLoading = true;
			
			// 1. 로딩 오버레이 씬 로드
			yield return _transitionScreenController.LoadAdditive();

			// 1-2. 트랜지션의 Fade In이 끝날 때까지 대기
			bool isFadeInCompleted = false;
			_changeScreenTransitionEvents.FadeInComplete += () => isFadeInCompleted = true;
			
			_changeScreenTransitionEvents.StartFadeIn?.Invoke();
			yield return new WaitUntil(() => isFadeInCompleted); 
			
			
			// 2. 실제 화면 변경
			yield return changeScreenAction();
			
			
			// 3. 트랜지션의 Fade Out이 끝날 때까지 대기
			bool isFadeOutCompleted = false;
			_changeScreenTransitionEvents.FadeOutComplete += () => isFadeOutCompleted = true;
			
			_changeScreenTransitionEvents.StartFadeOut?.Invoke();
			yield return new WaitUntil(() => isFadeOutCompleted);
			
			
			// 3-1. 로딩 오버레이 씬 언로드
			yield return _transitionScreenController.Unload();
			
			
			_isLoading = false;
		}
	}

}