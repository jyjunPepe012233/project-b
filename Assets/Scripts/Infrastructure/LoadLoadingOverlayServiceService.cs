using System.Collections;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine.SceneManagement;

namespace ProjectB.Infrastructure
{

	public class LoadLoadingOverlayServiceService : ILoadLoadingOverlayServicePort
	{
		private const string LOADING_OVERLAY_SCENE_NAME = "LoadingOverlay";
		
		public IEnumerator Load()
		{
			SceneManager.LoadScene(LOADING_OVERLAY_SCENE_NAME, LoadSceneMode.Additive);
			yield return null; // 로딩 화면 씬의 게임오브젝트가 모두 로딩되도록 한 프레임 대기
		}

		public IEnumerator Unload()
		{
			SceneManager.UnloadSceneAsync(LOADING_OVERLAY_SCENE_NAME); // 로딩 화면 씬 Unload
			yield break; // 대기하지 않고 함수 호출 후 바로 스킵
		}
	}

}