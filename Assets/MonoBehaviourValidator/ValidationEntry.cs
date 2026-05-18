using System;

namespace MonoBehaviourValidator
{

	public struct ValidationEntry
	{
		public string message;
		public Func<bool> validationFunc;

		public ValidationEntry(string message, Func<bool> validationFunc)
		{
			this.message = message;
			this.validationFunc = validationFunc;
		}
	}

}