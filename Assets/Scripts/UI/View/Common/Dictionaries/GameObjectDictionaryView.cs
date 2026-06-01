using UnityEngine;

namespace ProjectB.UI.View.Common.Dictionaries
{

	public class GameObjectDictionaryView : BasePrefabDictionaryView<string, GameObject>
	{
		protected override void SetActiveInternal(GameObject instance, bool active)
		{
			instance.SetActive(active);
		}
	}

}