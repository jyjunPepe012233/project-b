using System;

namespace ProjectB.UI.Core
{

	public abstract class UIPresenter : IDisposable
	{
		// Presenter를 관리하는 시스템이 직접 Initialize와 Dispose를 호출하도록 설계해야 함
		// 주로 MonoBehaviour의 Awake와 OnDestroy 시점에 각 메서드가 호출됨
		
		// 현재는 UIPresenterScope라는 MonoBehaviour가 이 역할을 담당하고 있음
		
		public virtual void Initialize()
		{
			SetupViewCallbacks();
			SetupModelSubscription();
		}

		public virtual void Dispose()
		{
			DisposeViewCallbacks();
			DisposeModelSubscription();
		}
		
		protected virtual void SetupViewCallbacks()
		{
			
		}

		protected virtual void DisposeViewCallbacks()
		{
			
		}

		protected virtual void SetupModelSubscription()
		{
			
		}
		
		protected virtual void DisposeModelSubscription()
		{
			
		}
	}

}
