using System.Collections;
using ProjectB.Gameplay.Internal.Ports.Screen;
using ProjectB.Gameplay.Outbound.Ports.Scene;

namespace ProjectB.Gameplay.Internal.Implements.Screen
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