using System;
using ProjectB.Core.Types;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface IUncaughtErrorCatcherPort
	{
		event Action<ErrorData> UncaughtErrorCaught;
	}

}