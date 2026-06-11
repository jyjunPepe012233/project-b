using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Inventory;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Lists;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Overlays
{

	public class BackpackOverlayPresenterScope : BaseOverlayPresenterScope<BackpackOverlayPresenter, BackpackOverlayEvents>
	{
		[SerializeField] private ButtonView _consumablePageButtonView;
		[SerializeField] private ButtonView _equipmentPageButtonView;
		
		[SerializeField] private ItemSlotListView _itemSlotListView;
		[SerializeField] private ItemSlotView _itemSlotPrefab;
		
		[SerializeField] private TopElementView _itemInfoDisabledView;
		[SerializeField] private TopElementView _itemInfoEnabledView;
		[SerializeField] private ItemSlotView _itemInfoSlotView;
		[SerializeField] private TextView _itemDescriptionView;
		[SerializeField] private ButtonView _consumeButtonView;
		
		[Inject] private InventoryEvents _inventoryEvents;
		[Inject] private IInventoryService _inventoryService;
		[Inject] private IConsumeItemService _consumeItemService;
		
		protected override BackpackOverlayPresenter Compose()
		{
			return new BackpackOverlayPresenter(_topElementView,
				_closeButtonView,
				_overlayEvents,
				_overlayStackService,
				_consumablePageButtonView,
				_equipmentPageButtonView,
				_itemSlotListView,
				_itemSlotPrefab,
				_itemInfoDisabledView,
				_itemInfoEnabledView,
				_itemInfoSlotView,
				_itemDescriptionView,
				_consumeButtonView,
				_inventoryEvents,
				_inventoryService,
				_consumeItemService);
		}
	}

}
