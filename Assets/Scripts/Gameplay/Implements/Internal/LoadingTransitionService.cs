using System;
using System.Collections;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay.Implements.Internal
{

	public class LoadingTransitionService : ILoadingTransitionService
	{
		private readonly ILoadingOverlayServicePort _loadingOverlayServicePort;

		private bool _isLoading = false;
		
		public LoadingTransitionService(ILoadingOverlayServicePort loadingOverlayServicePort)
		{
			_loadingOverlayServicePort = loadingOverlayServicePort;
		}
		
		public IEnumerator LoadScreenWithTransition(Func<IEnumerator> loadScreenAction)
		{
			if (_isLoading)
			{
				Debug.LogError("LoadingTransitionService: 이미 로딩이 진행 중인데 다시 로딩이 시도됨");
				yield break;
			}
			
			_isLoading = true;
			
			// 1. 로딩 오버레이 로드
			yield return _loadingOverlayServicePort.Load();

			// 1-2. 트랜지션의 Fade In이 끝날 때까지 대기
			yield return _loadingOverlayServicePort.OpenTransition();
			
			
			// 2. 실제 화면 로드
			yield return loadScreenAction();
			
			
			// 3. 트랜지션의 Fade Out이 끝날 때까지 대기
			yield return _loadingOverlayServicePort.CloseTransition();
			
			// 3-1. 로딩 오버레이를 언로드
			yield return _loadingOverlayServicePort.Unload();
			
			
			_isLoading = false;
		}
	}

}