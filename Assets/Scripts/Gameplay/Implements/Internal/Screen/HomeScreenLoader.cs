using System.Collections;
using ProjectB.Gameplay.Ports.Internal.Screen;
using ProjectB.Gameplay.Ports.Outbound.Scene;

namespace ProjectB.Gameplay.Implements.Internal.Screen
{

	public class HomeScreenLoader : IHomeScreenLoader
	{
		private readonly IControlScenePort _controlScenePort;

		public HomeScreenLoader(IControlScenePort controlScenePort)
		{
			_controlScenePort = controlScenePort;
		}

		public IEnumerator Load()
		{
			yield return _controlScenePort.LoadScene("HomeScreen");
		}
	}

}