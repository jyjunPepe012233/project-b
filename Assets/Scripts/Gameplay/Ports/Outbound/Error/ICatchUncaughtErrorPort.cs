using System;
using ProjectB.Core.Types;

namespace ProjectB.Gameplay.Ports.Outbound.Error
{

	public interface ICatchUncaughtErrorPort
	{
		event Action<ErrorData> UncaughtErrorCaught;
	}

}