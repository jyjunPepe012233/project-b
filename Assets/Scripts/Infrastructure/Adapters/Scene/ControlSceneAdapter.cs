using System.Collections;
using ProjectB.Gameplay.Outbound.Ports.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectB.Infrastructure.Adapters.Scene
{

	public class ControlSceneAdapter : IControlScenePort
	{
		private AsyncOperation _asyncOperation;


		public IEnumerator LoadScene(string sceneName)
		{
			yield return LoadSceneInternal(sceneName, LoadSceneMode.Single);
		}

		public IEnumerator LoadSceneAdditive(string sceneName)
		{
			yield return LoadSceneInternal(sceneName, LoadSceneMode.Additive);
		}
		
		IEnumerator LoadSceneInternal(string sceneName, LoadSceneMode loadSceneMode)
		{
			UnityEngine.SceneManagement.Scene oldScene = SceneManager.GetActiveScene();
			
			// 다음 씬 로딩(Additive)
			_asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
			yield return _asyncOperation;
			
			UnityEngine.SceneManagement.Scene nextScene = SceneManager.GetSceneByName(sceneName);
			if (!nextScene.IsValid())
			{
				// 씬 로드 실패 시 함수 종료
				Debug.LogError("SceneLoader: 씬 로드 실패: " + sceneName);
				yield break;
			}

			
			// Single 모드로 로드한 경우에는 이전 씬을 언로드
			if (loadSceneMode == LoadSceneMode.Single)
			{
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
					Debug.LogWarning("ControlSceneAdapter: 이전 씬이 로드되지 않았음: " + oldScene.name);
				}	
			}
			
			_asyncOperation = null;

			yield return null; // 씬 로드 완료 후 한 프레임 대기
		}
		

		public IEnumerator UnloadScene(string sceneName)
		{
			if (SceneManager.GetSceneByName(sceneName).isLoaded)
			{
				SceneManager.UnloadSceneAsync(sceneName);
			}
			else
			{
				Debug.LogWarning("ControlSceneAdapter: 언로드하려는 씬이 로드되지 않았음: " + sceneName);
				yield break;
			}
		}
	}

}