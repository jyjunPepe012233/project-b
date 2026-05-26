using System;
using System.Collections;
using ProjectB.Core.Supports;
using ProjectB.Data.Types;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectB.Infrastructure
{

	public class SceneLoadingTask : ILoadingTask
	{
		public bool IsDone => asyncOperation?.isDone ?? false;

		public float Progress => asyncOperation?.progress ?? 0;

		public Func<IEnumerator> LoadFunc => _loadFunc;

		protected readonly string _sceneName;
		protected readonly Func<IEnumerator> _loadFunc;
	
		private AsyncOperation asyncOperation;

		public SceneLoadingTask(string sceneName)
		{
			_sceneName = sceneName;
			_loadFunc = Load;
		}

		protected virtual IEnumerator Load()
		{
			// 26.05.26. 왜 LoadSceneMode.Single 방식으로 로드하는 게 아니라 Additive를 사용하는 거지?
			// 뭔가 이유가 있어서 이렇게 만들었던 것 같긴 한데, 관련 주석이 하나도 없어서 이해가 안됨.
			
			Scene oldScene = SceneManager.GetActiveScene();
			
			// 다음 씬 로딩(Additive)
			asyncOperation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
			yield return asyncOperation;
			
			Scene nextScene = SceneManager.GetSceneByName(_sceneName);
			if (!nextScene.IsValid())
			{
				// 씬 로드 실패 시 함수 종료
				Debug.LogError("SceneLoadingTask: 씬 로드 실패: " + _sceneName);
				yield break;
			}
				
			// Active 씬을 Additive로 로드한 씬으로 변경
			SceneManager.SetActiveScene(nextScene);
			
			// 이전 씬 언로드
			if (oldScene.isLoaded)
			{
				AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(oldScene);
				yield return unloadOp;
			}
			else
			{
				Debug.LogWarning("SceneLoadingTask: 이전 씬이 로드되지 않았음: " + oldScene.name);
			}
		}
	}

}
