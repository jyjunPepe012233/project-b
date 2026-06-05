using ProjectB.UI.Core;

namespace ProjectB.Infrastructure.Dependency.VContainer.PresenterScope
{

	public abstract class UIPresenterScope<TPresenter> : LifetimeScopeInjectionTarget where TPresenter : UIPresenter
	{
		protected TPresenter Presenter { get; private set; }
		
		protected bool IsInitialized { get; private set; }
		
		protected override void OnInjected()
		{
			base.OnInjected();
			Presenter = Compose();
			Presenter.Initialize();
		}

		protected virtual void OnEnable()
		{
			if (IsInjected && !IsInitialized)
			{
				IsInitialized = true;
				Presenter.Initialize();
			}
		}

		protected virtual void OnDisable()
		{
			if (IsInitialized)
			{
				Presenter.Dispose();
				IsInitialized = false;
			}
		}
		
		protected virtual void OnDestroy()
		{
			if (IsInitialized)
			{
				Presenter.Dispose();
				IsInitialized = false;
			}
		}

		protected abstract TPresenter Compose();
	}

}