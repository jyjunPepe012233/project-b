using System;
using System.Collections;
using ProjectB.Core.Supports;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class LoadingManager : ILoadingServicePort, ILoadingOverlayManagerPort
	{
		private ILoadingTaskPort _currentLoadingTask;
		
		
		public event Action LoadingStarted;
		public event Action LoadingFinished;

		private event Action _TransitionReadiedEvent;
		private event Action _TransitionDisposedEvent;
		
		
		private readonly ILoadLoadingOverlayServicePort _loadLoadingOverlayServicePort;
		
		public LoadingManager(ILoadLoadingOverlayServicePort loadLoadingOverlayServicePort)
		{
			_loadLoadingOverlayServicePort = loadLoadingOverlayServicePort;
		}
		
		
		
		public void TransitionReadied()
		{
			_TransitionReadiedEvent?.Invoke();
		}

		public void TransitionDisposed()
		{
			_TransitionDisposedEvent?.Invoke();
		}
	
		

		public void StartLoadingWithTransition(ILoadingTaskPort loadingTaskPort)
		{
			CoroutineHandler.StartAndAdd(Coroutine(loadingTaskPort));
		}

		IEnumerator Coroutine(ILoadingTaskPort loadingTaskPort)
		{
			if (_currentLoadingTask != null)
			{
				Debug.LogWarning($"[{nameof(LoadingManager)}] 이미 로딩이 진행 중입니다.");
				yield break;
			}
			
			_currentLoadingTask = loadingTaskPort;
			
			// 로딩 화면 로드
			yield return _loadLoadingOverlayServicePort.Load();
			LoadingStarted?.Invoke();


			// 트랜지션의 fade-in이 끝낼 때까지 대기
			bool isTransitionReadied = false;
			_TransitionReadiedEvent += () => isTransitionReadied = true;
			yield return new WaitUntil(() => isTransitionReadied);

			// 실제 로딩 시작
			loadingTaskPort.Load();
			
			// 실제 로딩이 끝날 때까지 대기
			yield return new WaitUntil(() => loadingTaskPort.IsDone);
			LoadingFinished?.Invoke();
			
			// 실제 로딩이 끝나면 트랜지션의 fade-out이 끝날 때까지 대기
			bool isTransitionDisposed = false;
			_TransitionDisposedEvent += () => isTransitionDisposed = true;
			yield return new WaitUntil(() => isTransitionDisposed);
			
			// 로딩 화면 Unload
			yield return _loadLoadingOverlayServicePort.Unload(); 

			_currentLoadingTask = null;
		}
	}

}