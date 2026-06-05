using ProjectB.UI.Core;

namespace ProjectB.Infrastructure.Dependency.VContainer.PresenterScope
{

	public abstract class UIPresenterScope<TPresenter> : LifetimeScopeInjectionTarget where TPresenter : UIPresenter
	{
		protected TPresenter Presenter { get; private set; }
		
		protected override void OnInjected()
		{
			base.OnInjected();
			Presenter = Compose();
			Presenter.Initialize();
		}

		protected virtual void OnEnable()
		{
			Presenter.Initialize();
		}

		protected virtual void OnDisable()
		{
			Presenter.Dispose();
		}
		
		protected virtual void OnDestroy()
		{
			if (Presenter != null)
			{
				Presenter.Dispose();
			}
		}

		protected abstract TPresenter Compose();
	}

}