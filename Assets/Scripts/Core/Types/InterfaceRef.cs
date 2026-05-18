using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProjectB.Core.Types
{

	[Serializable]
	public class InterfaceRef<T> where T : class
	{
		[SerializeField] private Object target;

		public T Value
		{
			get
			{
				if (_value == null)
				{
					_value = target as T;
				}

				return _value;
			}
		}

		private T _value;

		public Object Raw => target;


		public InterfaceRef(Object target)
		{
			this.target = target;
		}
	}

	[Serializable]
	public class InterfaceRefs<T> where T : class
	{
		[SerializeField] private Object[] targets;

		public IReadOnlyList<T> Value
		{
			get
			{
				if (_values == null)
				{
					_values = new T[targets?.Length ?? 0];
					for (int i = 0; i < _values.Length; i++)
					{
						_values[i] = targets[i] as T;
					}
				}

				return _values;
			}
		}

		private T[] _values;

		public IReadOnlyList<Object> Raw => targets;


		public InterfaceRefs(Object[] targets)
		{
			this.targets = targets;
		}
	}

}
