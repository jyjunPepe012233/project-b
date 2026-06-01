using System.Collections.Generic;
using UnityEngine;

namespace ProjectB.UI.View.Common
{

	public abstract class BasePrefabDictionaryView<TKey, TValue> : TopElementView where TValue : Object
	{
		private readonly Dictionary<TKey, TValue> _prefabDictionary = new Dictionary<TKey, TValue>();
		private readonly Dictionary<TKey, TValue> _instanceDictionary = new Dictionary<TKey, TValue>();
		
		private TValue _currentInstance;

		public Dictionary<TKey, TValue> Prefabs => _prefabDictionary;
		public Dictionary<TKey, TValue> Instances => _instanceDictionary;
		
		public TValue CurrentInstance => _currentInstance;
		
		public void RegisterPrefab(TKey key, TValue prefab)
		{
			if (!_prefabDictionary.ContainsKey(key))
			{
				_prefabDictionary.Add(key, prefab);
			}
			else
			{
				Debug.LogWarning($"PrefabDictionaryView: {key}는 이미 존재하는 키임");
			}
		}
		
		public bool IsPrefabRegistered(TKey key)
		{
			return _prefabDictionary.ContainsKey(key);
		}

		public TValue SetActiveInstance(TKey key)
		{
			if (_instanceDictionary.TryGetValue(key, out var instance))
			{
				SetActiveInternal(instance, true);
				_currentInstance = instance;
				return instance;
			}
			
			// instanceDictionary에 인스턴스가 없으면 prefabDictionary에서 프리팹을 찾아서 인스턴스화
			if (_prefabDictionary.TryGetValue(key, out var prefab))
			{
				var newInstance = Instantiate(prefab, transform, false);
				_instanceDictionary.Add(key, newInstance);
				_currentInstance = newInstance;
				return newInstance;
			}
			
			Debug.LogWarning($"PrefabDictionaryView: {key}에 해당하는 프리팹이 없음");
			return null;
		}
		
		public TValue RegisterAndSetActiveInstance(TKey key, TValue prefab)
		{
			if (!_prefabDictionary.ContainsKey(key))
			{
				return _prefabDictionary[key] = prefab;
			}
			
			return SetActiveInstance(key);
		}
		
		public void UnloadInstance()
		{
			if (_currentInstance != null)
			{
				SetActiveInternal(_currentInstance, false);
				_currentInstance = null;
			}
		}
		
		// GameObject나 Component의 .SetActive() 방식이 다르므로 각 방식에 맞게 구현하도록 추상 메서드로 정의
		protected abstract void SetActiveInternal(TValue instance, bool active);
	}

}