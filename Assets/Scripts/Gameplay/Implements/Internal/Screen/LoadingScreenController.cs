using System.Collections;
using ProjectB.Gameplay.Ports.Internal.Screen;
using ProjectB.Gameplay.Ports.Outbound.Scene;

namespace ProjectB.Gameplay.Implements.Internal.Screen
{

	public class LoadingScreenController : ILoadingScreenController
	{
		private readonly IControlScenePort _controlScenePort;

		public LoadingScreenController(IControlScenePort controlScenePort)
		{
			_controlScenePort = controlScenePort;
		}

		public IEnumerator LoadAdditive()
		{
			yield return _controlScenePort.LoadSceneAdditive("LoadingScreen");
		}

		public IEnumerator Unload()
		{
			yield return _controlScenePort.UnloadScene("LoadingScreen");
		}
	}

}