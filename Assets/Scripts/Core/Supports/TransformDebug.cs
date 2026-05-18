using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ProjectB.Core.Supports
{

	public static class TransformDebug
	{
		public static string GetHierarchyPath(Transform current)
		{
			if (current == null) return "<null>";
			
			StringBuilder sb = new StringBuilder();

			// string.Join에서는 역순으로 문자열이 조합되므로,
			// Stack을 사용하여 부모->자식 순으로 조회되게 함
			Stack<string> pathParts = new Stack<string>();
			while (current.parent != null)
			{
				pathParts.Push(current.name);
				current = current.parent;
			}
				
			return string.Join(".", pathParts);
		}

	}

}