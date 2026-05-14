using System.Linq;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Shop;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Buttons.ShopItemButton;
using ProjectB.UI.Buttons.ShopPageNavigateButton;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectB.UI.Screens.ShopScreen
{

	public class ShopScreenPresenter : UIPresenter<ShopScreenView>
	{
		[SerializeField] private InterfaceRef<IShopSetting> _shopSetting;
		[SerializeField] private ShopServicePortInstaller _shopServicePortInstaller;

		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			
			ShopPageNavigateButtonEvents.Clicked += OnShopPageNavigateButtonClicked;
			ShopItemButtonEvents.Clicked += OnShopItemButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			
			ShopPageNavigateButtonEvents.Clicked -= OnShopPageNavigateButtonClicked;
			ShopItemButtonEvents.Clicked -= OnShopItemButtonClicked;
		}
		
		void OnShopPageNavigateButtonClicked(IShopPage pageData)
		{
			if (pageData != null)
			{
				view.OpenPage(pageData);
			}
			else
			{
				Debug.LogError("전달된 페이지 데이터가 null임");
			}
		}
		
		void OnShopItemButtonClicked(IShopItem itemData)
		{
			if (itemData != null)
			{
				_shopServicePortInstaller.Port.BuyItem(itemData);
			}
			else
			{
				Debug.LogError("전달된 아이템 데이터가 null임");
			}
		}

		protected override void InitializeView()
		{
			base.InitializeView();
			view.InitializeNavigationButtons(_shopSetting.Value.ShopPages);
			view.InitializeShopPages(_shopSetting.Value.ShopPages);
			
			// IEnumerator는 사용 후 Dispose 해야 하므로 using문 사용 
			var pageData = _shopSetting.Value.ShopPages.FirstOrDefault();
			if (pageData != null)
			{
				view.OpenPage(pageData);
			}
			else
			{
				Debug.LogError("ShopSetting에 페이지 데이터가 존재하지 않음");
				return;
			}
		}
	}

}