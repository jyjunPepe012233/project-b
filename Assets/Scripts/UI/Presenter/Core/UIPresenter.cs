using System;

namespace ProjectB.UI.Core
{

	public abstract class UIPresenter : IDisposable
	{
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
