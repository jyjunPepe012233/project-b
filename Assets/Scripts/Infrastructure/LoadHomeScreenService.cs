using System.Collections;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine.SceneManagement;

namespace ProjectB.Infrastructure
{

	public class LoadHomeScreenService : ILoadHomeScreenPort
	{
		private const string SCENE_NAME = "Home"; 
		
		public IEnumerator Load()
		{
			SceneManager.LoadScene(SCENE_NAME, LoadSceneMode.Single);
			yield return null; // 씬의 오브젝트가 모두 로드될때까지 한 프레임 대기
		}

		public ILoadingTask GetLoadingTask()
		{
			return new SceneLoadingTask(SCENE_NAME);
		}
	}

}