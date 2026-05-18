using System.Collections.Generic;

using UnityEngine;

namespace MonoBehaviourValidator
{

	public static class TransformDebugExtension
	{
		public static string GetHierarchyPath(this Transform current)
		{
			if (current == null) return "<null>";
			
			Stack<string> pathParts = new Stack<string>();
			while (current != null)
			{
				pathParts.Push(current.name);
				current = current.parent;
			}
				
			return string.Join(".", pathParts);
		}

	}

}