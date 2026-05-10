using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;

namespace ProjectB.UI.Buttons.MenuButton
{

	public class MenuButtonPresenter : UIPresenter<ButtonView>
	{
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.ButtonClicked += OnButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.ButtonClicked -= OnButtonClicked;
		}
		
		void OnButtonClicked()
		{
			MenuButtonEvents.Clicked?.Invoke();
		}
	}

}