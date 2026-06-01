using UnityEngine;

namespace ProjectB.UI.Collections
{

	public class ComponentPrefabPool<T> : BasePrefabPool<T> where T : Component
	{
		public ComponentPrefabPool(Transform parentTransform, T prefab, int capacity = 0) : base(parentTransform, prefab, capacity)
		{
		}

		protected override void SetActiveObject(T obj, bool active)
		{
			obj.gameObject.SetActive(active);
		}
	}

}