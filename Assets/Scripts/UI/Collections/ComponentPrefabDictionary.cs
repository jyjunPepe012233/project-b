using UnityEngine;

namespace ProjectB.UI.Collections
{

	public class ComponentPrefabDictionary<TKey, TValue> : BasePrefabDictionary<TKey, TValue> where TValue : Component
	{
		public ComponentPrefabDictionary(Transform parentTransform, int capacity = 0) : base(parentTransform, capacity)
		{
		}
		
		protected override void SetActiveInternal(TValue instance, bool active)
		{
			instance.gameObject.SetActive(active);
		}
	}

}