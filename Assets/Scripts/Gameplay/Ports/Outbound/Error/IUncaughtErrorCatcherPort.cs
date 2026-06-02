using System;
using ProjectB.Core.Types;

namespace ProjectB.Gameplay.Ports.Outbound.Error
{

	public interface IUncaughtErrorCatcherPort
	{
		event Action<ErrorData> UncaughtErrorCaught;
	}

}