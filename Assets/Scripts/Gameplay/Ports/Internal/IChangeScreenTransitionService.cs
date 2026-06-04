using System;
using System.Collections;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface IChangeScreenTransitionService
	{
		void ChangeScreenWithTransition(Func<IEnumerator> changeScreenAction);
	}

}