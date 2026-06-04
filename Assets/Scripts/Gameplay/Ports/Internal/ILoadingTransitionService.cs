using System;
using System.Collections;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface ILoadingTransitionService
	{
		IEnumerator LoadScreenWithTransition(ILoadingTask loadingTask);
	}

}