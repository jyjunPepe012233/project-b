using System;
using System.Collections;

namespace ProjectB.Gameplay.Internal.Ports
{

	public interface IChangeScreenTransitionService
	{
		void ChangeScreenWithTransition(Func<IEnumerator> changeScreenAction);
	}

}