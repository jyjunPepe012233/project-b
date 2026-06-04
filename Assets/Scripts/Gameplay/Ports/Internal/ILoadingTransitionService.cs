using System;
using System.Collections;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface ILoadingTransitionService
	{
		void LoadScreenWithTransition(Func<IEnumerator> loadScreenAction);
	}

}