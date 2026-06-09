using ProjectB.Data.Static.Shop;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Lists;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace ProjectB.Infrastructure.UI.Overlays
{

	public class ShopOverlayPresenterScope : BaseOverlayPresenterScope<ShopOverlayPresenter, ShopOverlayEvents>
	{
		[SerializeField] private ShopItemCardListView _shopItemCardListView;
		[SerializeField] private ShopItemCardView _shopItemCardPrefab;
		[SerializeField] private TextView shopPageNameView;
		[SerializeField] private IconTextButtonListView _shopPageButtonListView;
		[SerializeField] private IconTextButtonView _shopPageButtonPrefab;
		
		[Inject] private IShopSetting _shopSetting; 
		[Inject] private IShopService _shopService;
		
		protected override ShopOverlayPresenter Compose()
		{
			return new ShopOverlayPresenter(_topElementView,
				_closeButtonView,
				_overlayEvents,
				_overlayStackService,
				_shopItemCardListView,
				_shopItemCardPrefab,
				shopPageNameView,
				_shopPageButtonListView,
				_shopPageButtonPrefab,
				_shopSetting,
				_shopService); 
		}
	}

}