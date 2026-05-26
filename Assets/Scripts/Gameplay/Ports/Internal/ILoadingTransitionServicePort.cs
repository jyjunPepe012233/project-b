using System;
using System.Collections;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface ILoadingTransitionServicePort
	{
		IEnumerator LoadScreenWithTransition(ILoadingTask loadingTask);
	}

}