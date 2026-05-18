using UnityEngine;

namespace ProjectB.UI.Core
{
	
	// UIPresenter가 제네릭 클래스 단독으로 있으면 외부에서 참조할 때 항상 제네릭을 명시해야함
	// 제네릭 타입 없이도 UIPresenter를 참조할 수 있도록 제네릭이 없는 상위 클래스를 만듬
	public abstract class BaseUIPresenter : MonoBehaviour
	{
		public abstract void Show();

		public abstract void Hide();
	}

}