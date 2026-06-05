using System.Collections;
using ProjectB.Gameplay.Ports.Internal.Screen;
using ProjectB.Gameplay.Ports.Outbound.Scene;

namespace ProjectB.Gameplay.Implements.Internal.Screen
{

	public class TransitionScreenController : ITransitionScreenController
	{
		private readonly IControlScenePort _controlScenePort;

		public TransitionScreenController(IControlScenePort controlScenePort)
		{
			_controlScenePort = controlScenePort;
		}

		public IEnumerator LoadAdditive()
		{
			yield return _controlScenePort.LoadSceneAdditive("TransitionScreen");
		}

		public IEnumerator Unload()
		{
			yield return _controlScenePort.UnloadScene("TransitionScreen");
		}
	}

}