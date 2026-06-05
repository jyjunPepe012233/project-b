using System;
using ProjectB.Core.Types;

namespace ProjectB.Gameplay.Outbound.Ports.Error
{

	public interface ICatchUncaughtErrorPort
	{
		event Action<ErrorData> UncaughtErrorCaught;
	}

}