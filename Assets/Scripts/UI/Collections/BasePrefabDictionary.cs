using System.Collections.Generic;
using UnityEngine;

namespace ProjectB.UI.Collections
{

	// 프리팹을 Key-value 형태로 저장하여 관리함
	// key에 따른 프리팹이 등록되면, 같은 key가 입력되었을 때 등록된 프리팹의 인스턴스를 활성화함
	
	// 즉, 특정 값-오브젝트 매핑이 필요한 경우에 사용하는 편의성 클래스임
	// 예: Soldier Role에 따라 Prefab 아이콘이 달라지므로 <SoldierRole, GameObject> 형태로 PrefabDictionary를 만들어서 관리할 수 있음
	
	public abstract class BasePrefabDictionary<TKey, TValue> where TValue : Object
	{
		private readonly Dictionary<TKey, TValue> _prefabDictionary;
		private readonly Dictionary<TKey, TValue> _instanceDictionary;
		
		private Transform _parentTransform;
		
		private TValue _currentInstance;

		protected BasePrefabDictionary(Transform parentTransform, int capacity = 0)
		{
			_parentTransform = parentTransform;
			_prefabDictionary = new Dictionary<TKey, TValue>(capacity);
			_instanceDictionary = new Dictionary<TKey, TValue>(capacity);
		}

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

		// 현재 활성화된 인스턴스가 있으면, key를 통해 얻은 인스턴스로 활성화 대상을 전환
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
				var newInstance = Object.Instantiate(prefab, _parentTransform, false);
				_instanceDictionary.Add(key, newInstance);
				_currentInstance = newInstance;
				return newInstance;
			}
			
			Debug.LogWarning($"PrefabDictionaryView: {key}에 해당하는 프리팹이 없음");
			return null;
		}
		
		// prefab이 등록되어 있지 않으면 등록하고 인스턴스화하여 활성화
		public TValue RegisterAndSetActiveInstance(TKey key, TValue prefab)
		{
			if (!_prefabDictionary.ContainsKey(key))
			{
				_prefabDictionary[key] = prefab;
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