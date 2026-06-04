using System;
using System.Collections;
using ProjectB.Core.Supports;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Internal.Screen;
using UnityEngine;

namespace ProjectB.Gameplay.Implements.Internal
{

	public class ChangeScreenTransitionService : IChangeScreenTransitionService
	{
		private readonly ChangeScreenTransitionEvents _changeScreenTransitionEvents;
		private readonly ILoadingScreenController _loadingScreenController;

		private bool _isLoading = false;

		public ChangeScreenTransitionService(ChangeScreenTransitionEvents changeScreenTransitionEvents, ILoadingScreenController loadingScreenController)
		{
			_changeScreenTransitionEvents = changeScreenTransitionEvents;
			_loadingScreenController = loadingScreenController;
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
			yield return _loadingScreenController.LoadAdditive();

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
			yield return _loadingScreenController.Unload();
			
			
			_isLoading = false;
		}
	}

}