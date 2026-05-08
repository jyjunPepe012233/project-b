using System;

namespace ProjectB.Core.Types
{

	public class ErrorData
	{
		public Exception exception;

		public string message;

		public string stackTrace;

		public bool isFatal; // LogError라면 False, Catch되지 않은 예외거나 크래시 로그면 True 등등

		public ErrorData(Exception exception, string message, string stackTrace, bool isFatal)
		{
			this.exception = exception;
			this.message = message;
			this.stackTrace = stackTrace;
			this.isFatal = isFatal;
		}
	}

}