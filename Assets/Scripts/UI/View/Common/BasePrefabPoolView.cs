using System.Collections.Generic;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.View.Common
{
	public abstract class BasePrefabPoolView<T> : TopElementView where T : Object
	{
		private readonly List<T> _activeObjects = new List<T>();
		private readonly List<T> _poolObjects = new List<T>();
		
		private T _prefab;
		
		public IReadOnlyList<T> ActiveObjects => _activeObjects;
		public IReadOnlyList<T> PoolObjects => _poolObjects;

		public void SetPrefab(T prefab)
		{
			_prefab = prefab;
		}
		
		public T Load()
		{
			if (_prefab == null)
			{
				Debug.LogWarning($"PrefabPoolView: {typeof(T).Name} 프리팹이 설정되지 않음");
				return null;
			}
			
			if (_poolObjects.Count > 0)
			{
				int lastIndex = _poolObjects.Count - 1;
				var obj = _poolObjects[lastIndex];
				_poolObjects.RemoveAt(lastIndex);
				
				SetActiveObject(obj, true);
				_activeObjects.Add(obj);
				return obj;
			}
			else
			{
				var newObj = Instantiate(_prefab, transform, false);
				_activeObjects.Add(newObj);
				return newObj;
			}
		}

		public void UnloadAll()
		{
			foreach (var obj in _activeObjects)
			{
				SetActiveObject(obj, false);
				_poolObjects.Add(obj);
			}
			_activeObjects.Clear();
		}
		
		protected abstract void SetActiveObject(T obj, bool active);
	}

}