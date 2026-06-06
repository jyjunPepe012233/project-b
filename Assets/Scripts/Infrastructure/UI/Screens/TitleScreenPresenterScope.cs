using ProjectB.Gameplay.Inbound.Ports.Screen;
using ProjectB.UI.Presenters.Screens;
using ProjectB.UI.Views.Buttons;
using VContainer;

namespace ProjectB.Infrastructure.Dependency.VContainer.PresenterScope
{

	public class TitleScreenPresenterScope : UIPresenterScope<TitleScreenPresenter>
	{
		public ButtonView clickAreaView;

		[Inject]
		public ITitleScreenManager titleScreenManager;
		
		protected override TitleScreenPresenter Compose()
		{
			return new TitleScreenPresenter(clickAreaView, titleScreenManager);
		}
	}

}