using System;

namespace MonoBehaviourValidator
{

	public struct ValidationEntry
	{
		public string name;
		public Func<bool> validationFunc;

		public ValidationEntry(string name, Func<bool> validationFunc)
		{
			this.name = name;
			this.validationFunc = validationFunc;
		}
	}

}