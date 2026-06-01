using System.Collections.Generic;
using UnityEngine;

namespace ProjectB.UI.View.Common
{

	public class PrefabDictionaryView<TKey, TValue> : TopElementView where TValue : Component
	{
		private readonly Dictionary<TKey, TValue> _prefabDictionary = new Dictionary<TKey, TValue>();
		private readonly Dictionary<TKey, TValue> _instanceDictionary = new Dictionary<TKey, TValue>();
		
		private TValue _currentInstance;
		
		public void AddPrefab(TKey key, TValue prefab)
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

		public TValue SetActiveInstance(TKey key)
		{
			if (_instanceDictionary.TryGetValue(key, out var instance))
			{
				instance.gameObject.SetActive(true);
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
		
		public void UnloadInstance()
		{
			if (_currentInstance != null)
			{
				_currentInstance.gameObject.SetActive(false);
				_currentInstance = null;
			}
		}
	}

}