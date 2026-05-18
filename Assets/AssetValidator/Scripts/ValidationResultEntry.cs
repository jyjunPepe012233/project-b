using System;
using UnityEngine;

namespace AssetValidator
{

	[Serializable]
	public struct ValidationResultEntry
	{
		public bool isValid;
		public string name;
		public GameObject prefab;
		public string hierarchyPath;

		public ValidationResultEntry(bool isValid, string name, GameObject prefab, string hierarchyPath)
		{
			this.isValid = isValid;
			this.name = name;
			this.prefab = prefab;
			this.hierarchyPath = hierarchyPath;
		}
	}

}