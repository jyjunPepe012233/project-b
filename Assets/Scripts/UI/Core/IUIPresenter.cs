namespace ProjectB.UI.Core
{
	
	// 제네릭 클래스인 UIPresenter<>를 외부에서 참조하기 위해 만든 인터페이스임
	public interface IUIPresenter
	{
		void Show();

		void Hide();
	}

}