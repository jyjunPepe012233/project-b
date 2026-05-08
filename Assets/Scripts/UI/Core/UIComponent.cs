using UnityEngine;

namespace ProjectB.UI.Core
{

	// UI Component는 자주적으로만 작동해야하는 UI Presenter의 확장된 형태임
	// UI Presenter가 스스로 작동하는 UI라면,
	// UI Component는 다른 클래스에게 제어받아야 하는 UI를 구현하는 데에 사용됨
	// 외부에서 사용 가능한 Show, Hide 메서드를 제공함
	public abstract class UIComponent<TView> : UIPresenter<TView> where TView : UIView
	{
		[SerializeField] protected bool initializeOnShow = true;
		
		public void Show()
		{
			if (initializeOnShow)
			{
				InitializeView();
			}
			
			view?.Show();
		}

		public void Hide()
		{
			view?.Hide();
		}
	}

}