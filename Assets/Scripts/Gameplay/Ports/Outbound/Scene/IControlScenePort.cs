using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound.Scene
{

	public interface IControlScenePort
	{
		IEnumerator LoadScene(string sceneName);
		
		IEnumerator LoadSceneAdditive(string sceneName);
		
		IEnumerator UnloadScene(string sceneName);
	}

}