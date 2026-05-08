using ProjectB.Core.Types;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface IReportErrorPort
	{
		void Report(ErrorData errorData);
	}

}