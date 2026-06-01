using UnityEngine;

namespace ProjectB.UI.Collections
{

	public class PrefabDictionary<TKey> : BasePrefabDictionary<TKey, GameObject>
	{
		public PrefabDictionary(Transform parentTransform, int capacity = 0) : base(parentTransform, capacity)
		{
		}

		protected override void SetActiveInternal(GameObject instance, bool active)
		{
			instance.SetActive(active);
		}
	}

}