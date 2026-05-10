using ProjectB.UI.Buttons.MenuButton;
using ProjectB.UI.Core;

namespace ProjectB.UI.Popups.MenuPopup
{

	public class MenuPopupPresenter : UIComponent<MenuPopupView>
	{
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			MenuButtonEvents.Clicked += OnMenuButtonClicked;
			
			view.CloseButtonClicked += OnCloseButtonClicked; 
			view.OpenBackpackButtonClicked += OnOpenBackpackButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			MenuButtonEvents.Clicked -= OnMenuButtonClicked;
			
			view.CloseButtonClicked -= OnCloseButtonClicked;
			view.OpenBackpackButtonClicked -= OnOpenBackpackButtonClicked;
		}
		
		void OnMenuButtonClicked()
		{
			Show();
		}
		
		void OnCloseButtonClicked()
		{
			Hide();
		}

		void OnOpenBackpackButtonClicked()
		{
			
			Hide();
		}
	}

}