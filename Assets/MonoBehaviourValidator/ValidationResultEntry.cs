using UnityEngine;

namespace MonoBehaviourValidator
{
	
	public struct ValidationResultEntry
	{
		public readonly bool isValid;
		public readonly string message;
		public readonly GameObject prefab;
		public readonly string hierarchyPath;

		public ValidationResultEntry(bool isValid, string message, GameObject prefab, string hierarchyPath)
		{
			this.isValid = isValid;
			this.message = message;
			this.prefab = prefab;
			this.hierarchyPath = hierarchyPath;
		}
	}

}