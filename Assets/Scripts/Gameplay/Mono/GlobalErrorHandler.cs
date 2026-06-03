using ProjectB.Core.Types;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Gameplay.Ports.Outbound.Error;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class GlobalErrorHandler
	{
		private readonly IUncaughtErrorCatcherPort _uncaughtErrorCatcherPort;
		private readonly IReportErrorPort _reportErrorPort;

		public GlobalErrorHandler(IUncaughtErrorCatcherPort uncaughtErrorCatcherPort, IReportErrorPort reportErrorPort)
		{
			_uncaughtErrorCatcherPort = uncaughtErrorCatcherPort;
			_reportErrorPort = reportErrorPort;
			
			_uncaughtErrorCatcherPort.UncaughtErrorCaught += OnUncaughtErrorCaught;
		}

		void OnUncaughtErrorCaught(ErrorData errorData)
		{
			_reportErrorPort.Report(errorData);
		}
	}

}