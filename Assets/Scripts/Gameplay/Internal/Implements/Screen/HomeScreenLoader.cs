using System.Collections;
using ProjectB.Gameplay.Internal.Ports.Screen;
using ProjectB.Gameplay.Outbound.Ports.Scene;

namespace ProjectB.Gameplay.Internal.Implements.Screen
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