using ProjectB.Core.Types;

namespace ProjectB.Gameplay.Outbound.Ports.Error
{

	public interface IReportErrorPort
	{
		void Report(ErrorData errorData);
	}

}