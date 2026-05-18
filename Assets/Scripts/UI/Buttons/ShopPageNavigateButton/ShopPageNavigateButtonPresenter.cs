using ProjectB.Data.Static.Shop;
using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;

namespace ProjectB.UI.Buttons.ShopPageNavigateButton
{

	public class ShopPageNavigateButtonPresenter : UIPresenter<ShopPageNavigateButtonView>
	{
		private IShopPage _targetPage;
		
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
			ShopPageNavigateButtonEvents.Clicked?.Invoke(_targetPage);
		}

		public void InitializeNavigation(IShopPage targetPage)
		{
			_targetPage = targetPage;
			view.SetPageName(targetPage.ShopPageName);
		}
	}

}