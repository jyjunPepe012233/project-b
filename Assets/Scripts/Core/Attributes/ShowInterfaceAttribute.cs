using System;
using UnityEngine;

namespace ProjectB.Core.Attributes
{

	[AttributeUsage(AttributeTargets.Field)]
	public class ShowInterfaceAttribute : PropertyAttribute
	{
		public readonly Type InterfaceType;

		public ShowInterfaceAttribute(Type interfaceType)
		{
			InterfaceType = interfaceType;
		}
	}

}
