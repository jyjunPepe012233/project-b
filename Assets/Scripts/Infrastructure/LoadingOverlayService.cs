using System;
using System.Collections;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.UI.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace ProjectB.Infrastructure
{

	public class LoadingOverlayService : ILoadingOverlayServicePort
	{
		private const string LOADING_OVERLAY_SCENE_NAME = "LoadingOverlay";

		private LoadingOverlayControlService _uiService;
		public LoadingOverlayControlService UIService
		{
			get
			{
				if (_uiService == null)
				{
					_uiService = Object.FindObjectOfType<LoadingOverlayControlService>();
					if (_uiService == null)
					{
						Debug.LogError("LoadingOverlayControlService를 찾을 수 없음");
						return null;
					}
				}
				
				return _uiService;
			}
		}

		public IEnumerator Load()
		{
			SceneManager.LoadScene(LOADING_OVERLAY_SCENE_NAME, LoadSceneMode.Additive);
			yield return null; // 로딩 화면 씬의 게임오브젝트가 모두 로딩되도록 한 프레임 대기
		}

		public IEnumerator OpenTransition()
		{
			yield return UIService.OpenTransition();
		}

		public IEnumerator CloseTransition()
		{
			yield return UIService.CloseTransition();
		}

		public IEnumerator Unload()
		{
			SceneManager.UnloadSceneAsync(LOADING_OVERLAY_SCENE_NAME); // 로딩 화면 씬 Unload
			yield break; // 대기하지 않고 함수 호출 후 바로 스킵
		}
	}

}