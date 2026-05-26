using System.Collections;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class LoadingTransitionService : ILoadingTransitionServicePort
	{
		private readonly ILoadingOverlayServicePort _loadingOverlayServicePort;

		private ILoadingTask _currentLoadingTask;
		
		public LoadingTransitionService(ILoadingOverlayServicePort loadingOverlayServicePort)
		{
			_loadingOverlayServicePort = loadingOverlayServicePort;
		}
		
		public IEnumerator LoadScreenWithTransition(ILoadingTask loadingTask)
		{
			if (_currentLoadingTask != null)
			{
				Debug.LogError("LoadingTransitionService: 이미 로딩이 진행 중인데 다시 로딩이 시도됨");
				yield break;
			}
			
			_currentLoadingTask = loadingTask;
			
			
			// 1. 로딩 오버레이 로드
			yield return _loadingOverlayServicePort.Load();

			// 1-2. 트랜지션의 Fade In이 끝날 때까지 대기
			yield return _loadingOverlayServicePort.OpenTransition();
			
			
			// 2. 실제 화면 로드
			yield return loadingTask.LoadFunc();
			
			// 2-1. 실제 화면 로드가 완료될때까지 대기
			yield return new WaitUntil(() => loadingTask.IsDone);
			
			
			// 3. 트랜지션의 Fade Out이 끝날 때까지 대기
			yield return _loadingOverlayServicePort.CloseTransition();
			
			// 3-1. 로딩 오버레이를 언로드
			yield return _loadingOverlayServicePort.Unload();
			
			
			_currentLoadingTask = null;
		}
	}

}