using ProjectB.Core.Types;
using ProjectB.Data.Static.Shop;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Label;
using ProjectB.UI.Views.Lists;
using UnityEngine;

namespace ProjectB.Infrastructure.UI.Overlays
{

	public class ShopOverlayPresenterScope : BaseOverlayPresenterScope<ShopOverlayPresenter, ShopOverlayEvents>
	{
		[SerializeField] private ShopItemCardListView _shopItemCardListView;
		[SerializeField] private TextLabelView _shopPageNameLabelView;
		[SerializeField] private IconTextButtonListView _shopPageButtonListView;
		[SerializeField] private ShopItemCardView _shopItemCardPrefab;
		
		[Header("Data")]
		[SerializeField] private InterfaceRef<IShopSetting> _shopSetting;
		
		protected override ShopOverlayPresenter Compose()
		{
			return new ShopOverlayPresenter(_topElementView,
				_closeButtonView,
				_overlayEvents,
				_overlayStackService,
				_shopItemCardListView,
				_shopPageNameLabelView,
				_shopPageButtonListView,
				_shopItemCardPrefab,
				_shopSetting.Value);
		}
	}

}