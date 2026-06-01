using System.Collections.Generic;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.View.Common
{

	public class PrefabPoolView<T> : UIView where T : Component
	{
		private readonly List<T> _activeObjects = new List<T>();
		private readonly List<T> _poolObjects = new List<T>(); 
		
		public IReadOnlyList<T> ActiveObjects => _activeObjects;
		public IReadOnlyList<T> PoolObjects => _poolObjects;
		
		public T Load(T prefab)
		{
			if (_poolObjects.Count > 0)
			{
				int lastIndex = _poolObjects.Count - 1;
				var obj = _poolObjects[lastIndex];
				_poolObjects.RemoveAt(lastIndex);
				
				obj.gameObject.SetActive(true);
				_activeObjects.Add(obj);
				return obj;
			}
			else
			{
				var newObj = Instantiate(prefab, transform, false);
				_activeObjects.Add(newObj);
				return newObj;
			}
		}

		public void UnloadAll()
		{
			foreach (var obj in _activeObjects)
			{
				obj.gameObject.SetActive(false);
				_poolObjects.Add(obj);
			}
			_activeObjects.Clear();
		}
	}

}