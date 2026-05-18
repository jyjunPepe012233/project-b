using System;
using System.Collections.Generic;

namespace MonoBehaviourValidator
{

	public class ValidationMethod
	{
		public List<ValidationEntry> validationEntries = new List<ValidationEntry>();
		
		// Return self for method chaining
		public ValidationMethod Register(string name, Func<bool> validationFunc)
		{
			validationEntries.Add(new ValidationEntry(name, validationFunc));
			return this;
		}
	}

}