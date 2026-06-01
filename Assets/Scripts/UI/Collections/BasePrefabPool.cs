using System.Collections.Generic;
using UnityEngine;

namespace ProjectB.UI.Collections
{
	public abstract class BasePrefabPool<T> where T : Object
	{
		private readonly List<T> _activeObjects;
		private readonly List<T> _poolObjects;
		
		private Transform _parentTransform;
		private T _prefab;

		protected BasePrefabPool(Transform parentTransform, T prefab, int capacity = 0)
		{
			_activeObjects = new List<T>(capacity);
			_poolObjects = new List<T>(capacity);
			
			_parentTransform = parentTransform;
			_prefab = prefab;
		}

		public IReadOnlyList<T> ActiveObjects => _activeObjects;
		public IReadOnlyList<T> PoolObjects => _poolObjects;
		
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
				var newObj = Object.Instantiate(_prefab, _parentTransform, false);
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