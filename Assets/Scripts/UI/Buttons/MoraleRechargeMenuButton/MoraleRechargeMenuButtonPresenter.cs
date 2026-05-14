using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;

namespace ProjectB.UI.Buttons.MoraleRechargeMenuButton
{

	public class MoraleRechargeMenuButtonPresenter : UIPresenter<ButtonView>
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
			MoraleRechargeMenuButtonEvents.Clicked?.Invoke();
		}
	}

}
