using ProjectB.Core.Types;

namespace ProjectB.Gameplay.Ports.Outbound.Error
{

	public interface IReportErrorPort
	{
		void Report(ErrorData errorData);
	}

}