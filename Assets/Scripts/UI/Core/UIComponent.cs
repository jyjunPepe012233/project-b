using System;
using UnityEngine;

namespace ProjectB.UI.Core
{

	// UI Component는 자주적으로만 작동해야하는 UI Presenter의 확장된 형태임
	// UI Presenter가 스스로 작동하는 UI라면,
	// UI Component는 다른 클래스에게 제어받아야 하는 UI를 구현하는 데에 사용됨
	// 외부에서 사용 가능한 Show, Hide 메서드를 제공함
	
	[Obsolete("UIComponent의 기능은 UIPresenter로 통합되었습니다.", true)]
	// UIPresenter 또한 외부 UI 시스템에게 제어가 필요한 경우가 많아서, UIComponent와 UIPresenter를 구분하지 않게 되었음
	// 예를 들어, "플레이어 데이터에서 직접 데이터를 받아와서 표시하는 체력바"라도 페이지가 닫히면 UI를 숨기는 등, UIComponent의 Show, Hide 메서드가 필요한 경우가 많았음
	// 그래서 UIComponent의 기능을 UIPresenter로 통합하기로 결정했음
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