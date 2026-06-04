using ProjectB.UI.Core;

namespace ProjectB.Infrastructure.Dependency.VContainer.PresenterComposer
{

	public abstract class UIPresenterComposer<TPresenter> : LifetimeScopeInjectionTarget where TPresenter : UIPresenter
	{
		protected TPresenter Presenter { get; private set; }
		
		protected override void OnInjected()
		{
			base.OnInjected();
			Presenter = Compose();
		}

		protected abstract TPresenter Compose();
	}

}