using ProjectB.Core.Types;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Gameplay.Ports.Outbound.Error;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class GlobalErrorHandler
	{
		private readonly ICatchUncaughtErrorPort _catchUncaughtErrorPort;
		private readonly IReportErrorPort _reportErrorPort;

		public GlobalErrorHandler(ICatchUncaughtErrorPort catchUncaughtErrorPort, IReportErrorPort reportErrorPort)
		{
			_catchUncaughtErrorPort = catchUncaughtErrorPort;
			_reportErrorPort = reportErrorPort;
			
			_catchUncaughtErrorPort.UncaughtErrorCaught += OnUncaughtErrorCaught;
		}

		void OnUncaughtErrorCaught(ErrorData errorData)
		{
			_reportErrorPort.Report(errorData);
		}
	}

}