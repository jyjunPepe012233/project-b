using UnityEngine;

namespace ProjectB.UI.View.Common.Pools
{

	// Component(T) 타입의 프리팹을 관리하는 클래스를 생성하기 위한 추상 클래스
	// Serialize를 위해서는 이 클래스를 상속받아 비제네릭 클래스를 만들어야 함.
	public abstract class ComponentPrefabPoolView<T> : BasePrefabPoolView<T> where T : Component
	{
		protected override void SetActiveObject(T obj, bool active)
		{
			obj.gameObject.SetActive(active);
		}
	}

}