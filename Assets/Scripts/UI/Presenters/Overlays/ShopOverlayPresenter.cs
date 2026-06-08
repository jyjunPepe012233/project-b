using System;
using System.Collections.Generic;
using ProjectB.Data.Static.Shop;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Label;
using ProjectB.UI.Views.Lists;

namespace ProjectB.UI.Presenters.Overlays
{

	public class ShopOverlayPresenter : BaseOverlayPresenter<ShopOverlayEvents>
	{
		private readonly ShopItemCardListView _shopItemCardListView;
		private readonly TextLabelView _shopPageNameLabelView;
		private readonly IconTextButtonListView _shopPageButtonListView;
		private readonly ShopItemCardView _shopItemCardPrefab;

		private readonly IShopSetting _shopSetting;
		
		public ShopOverlayPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			ShopOverlayEvents overlayEvents,
			IOverlayStackService overlayStackService,
			ShopItemCardListView shopItemCardListView,
			TextLabelView shopPageNameLabelView,
			IconTextButtonListView shopPageButtonListView,
			ShopItemCardView shopItemCardPrefab,
			IShopSetting shopSetting) : base(topElementView, closeButtonView, overlayEvents, overlayStackService)
		{
			_shopItemCardListView = shopItemCardListView;
			_shopPageNameLabelView = shopPageNameLabelView;
			_shopPageButtonListView = shopPageButtonListView;
			_shopItemCardPrefab = shopItemCardPrefab;
			_shopSetting = shopSetting;
		}

		public override void Initialize()
		{
			base.Initialize();
			_shopItemCardListView.Initialize(_shopItemCardPrefab);
		}

		protected override void OnOpenScreen()
		{
			base.OnOpenScreen();
			
			InitializeShopPageButtons();

			if (_shopSetting.ShopPages.Count > 0)
			{
				SetShopPageName(_shopSetting.ShopPages[0].ShopPageName);
				InitializeShopItemCardList(_shopSetting.ShopPages[0].ShopItems);
			}
		}
		
		protected virtual void InitializeShopPageButtons()
		{
			_shopPageButtonListView.ClearItems();
			
			foreach (var shopPage in _shopSetting.ShopPages)
			{
				var shopPageButton = _shopPageButtonListView.CreateItem();
				shopPageButton.SetText(shopPage.ShopPageName);
				shopPageButton.ButtonClicked += () => OnShopPageButtonClicked(shopPage);
			}
		}
		
		void OnShopPageButtonClicked(IShopPage shopPage)
		{
			SetShopPageName(shopPage.ShopPageName);
			InitializeShopItemCardList(shopPage.ShopItems);
		}
		
		protected virtual void SetShopPageName(string shopPageName)
		{ 
			_shopPageNameLabelView.SetText(shopPageName);
		}
		
		protected virtual void InitializeShopItemCardList(IEnumerable<IShopItem> shopItems)
		{
			_shopItemCardListView.ClearItems();
			
			foreach (var shopItem in shopItems)
			{
				var shopItemCard = _shopItemCardListView.CreateItem();
				shopItemCard.Initialize(shopItem.ItemData.ItemName,
					shopItem.Quantity,
					shopItem.Price,
					shopItem.ItemData.Icon128,
					shopItem.ItemData.ItemTier.BackgroundPrefab128);
			}
		}
	}

}
