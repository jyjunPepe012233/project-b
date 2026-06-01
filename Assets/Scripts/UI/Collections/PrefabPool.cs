using UnityEngine;

namespace ProjectB.UI.Collections
{

	public class PrefabPool : BasePrefabPool<GameObject>
	{
		public PrefabPool(Transform parentTransform, GameObject prefab, int capacity = 0) : base(parentTransform, prefab, capacity)
		{
		}

		protected override void SetActiveObject(GameObject obj, bool active)
		{
			obj.SetActive(active);
		}
	}

}