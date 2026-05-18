using System;
using System.Collections.Generic;

namespace MonoBehaviourValidator
{

	public class ValidationMethod
	{
		public List<ValidationEntry> validationEntries = new List<ValidationEntry>();
		
		// Return self for method chaining
		public ValidationMethod Register(string message, Func<bool> validationFunc)
		{
			validationEntries.Add(new ValidationEntry(message, validationFunc));
			return this;
		}
	}

}