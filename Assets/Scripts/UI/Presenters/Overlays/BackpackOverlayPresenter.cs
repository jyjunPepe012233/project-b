using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Inventory;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Lists;

namespace ProjectB.UI.Presenters.Overlays
{

	public class BackpackOverlayPresenter : BaseOverlayPresenter<BackpackOverlayEvents>
	{
		private readonly ButtonView _consumablePageButtonView;
		private readonly ButtonView _equipmentPageButtonView;
		
		private readonly ItemSlotListView _itemSlotListView;
		private readonly ItemSlotView _itemSlotPrefab;
		
		private readonly TopElementView _itemInfoDisabledView;
		private readonly TopElementView _itemInfoEnabledView;
		private readonly ItemSlotView _itemInfoSlotView;
		private readonly TextView _itemDescriptionView;
		private readonly ButtonView _consumeButtonView;

		private readonly InventoryEvents _inventoryEvents;
		private readonly IInventoryService _inventoryService;
		private readonly IConsumeItemService _consumeItemService;

		
		private ItemCategory _currentCategory;
		private IReadOnlyPlayerItem _currentPlayerItem;

		public BackpackOverlayPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			BackpackOverlayEvents overlayEvents,
			IOverlayStackService overlayStackService,
			ButtonView consumablePageButtonView,
			ButtonView equipmentPageButtonView,
			ItemSlotListView itemSlotListView,
			ItemSlotView itemSlotPrefab,
			TopElementView itemInfoDisabledView,
			TopElementView itemInfoEnabledView,
			ItemSlotView itemInfoSlotView,
			TextView itemDescriptionView,
			ButtonView consumeButtonView,
			InventoryEvents inventoryEvents,
			IInventoryService inventoryService,
			IConsumeItemService consumeItemService) : base(topElementView, closeButtonView, overlayEvents, overlayStackService)
		{
			_consumablePageButtonView = consumablePageButtonView;
			_equipmentPageButtonView = equipmentPageButtonView;
			_itemSlotListView = itemSlotListView;
			_itemSlotPrefab = itemSlotPrefab;
			_itemInfoDisabledView = itemInfoDisabledView;
			_itemInfoEnabledView = itemInfoEnabledView;
			_itemInfoSlotView = itemInfoSlotView;
			_itemDescriptionView = itemDescriptionView;
			_consumeButtonView = consumeButtonView;
			_inventoryEvents = inventoryEvents;
			_inventoryService = inventoryService;
			_consumeItemService = consumeItemService;
		}

		public override void Initialize()
		{
			base.Initialize();
			_itemSlotListView.Initialize(_itemSlotPrefab);
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_consumablePageButtonView.ButtonClicked += OnConsumablePageButtonClicked;
			_equipmentPageButtonView.ButtonClicked += OnEquipmentPageButtonClicked;
			_consumeButtonView.ButtonClicked += OnConsumeButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_consumablePageButtonView.ButtonClicked -= OnConsumablePageButtonClicked;
			_equipmentPageButtonView.ButtonClicked -= OnEquipmentPageButtonClicked;
			_consumeButtonView.ButtonClicked -= OnConsumeButtonClicked;
		}

		void OnConsumablePageButtonClicked()
		{
			if (_currentCategory == ItemCategory.Consumable)
			{
				return;
			}

			OpenPage(ItemCategory.Consumable);
		}

		void OnEquipmentPageButtonClicked()
		{
			if (_currentCategory == ItemCategory.Equipment)
			{
				return;
			}

			OpenPage(ItemCategory.Equipment);
		}

		void OnConsumeButtonClicked()
		{
			_consumeItemService.ConsumeItem(_currentPlayerItem.ItemData);
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_inventoryEvents.InventoryUpdated += OnInventoryUpdated;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_inventoryEvents.InventoryUpdated -= OnInventoryUpdated;
		}

		void OnInventoryUpdated()
		{
			InitializeItemSlotList();

			if (_inventoryService.Items.All(playerItem => playerItem != _currentPlayerItem))
			{
				ClearItemInfo();
			}
			else
			{
				InitializeItemInfo(_currentPlayerItem);
			}
		}

		protected override void OnOpenScreen()
		{
			base.OnOpenScreen();
			OpenPage(ItemCategory.Consumable);
		}

		protected override void OnShowScreen()
		{
			base.OnShowScreen();
			InitializeItemSlotList();

			if (_currentPlayerItem == null)
			{
				ClearItemInfo();
			}
			else
			{
				InitializeItemInfo(_currentPlayerItem);
			}
		}

		void OpenPage(ItemCategory category)
		{
			_currentCategory = category;
			InitializeItemSlotList();
			ClearItemInfo();
		}

		protected virtual void InitializeItemSlotList()
		{
			_itemSlotListView.ClearItems();

			foreach (var playerItem in _inventoryService.Items.Where(playerItem => playerItem.ItemData.Category == _currentCategory))
			{
				var itemSlot = _itemSlotListView.CreateItem();
				itemSlot.Initialize(playerItem.ItemData.ItemName,
					playerItem.Quantity,
					playerItem.ItemData.Icon128,
					playerItem.ItemData.ItemTier.BackgroundPrefab128);

				itemSlot.ButtonClicked += () => OnItemSlotClicked(playerItem);
			}
		}

		void OnItemSlotClicked(IReadOnlyPlayerItem playerItem)
		{
			InitializeItemInfo(playerItem);
		}

		void InitializeItemInfo(IReadOnlyPlayerItem playerItem)
		{
			_currentPlayerItem = playerItem;

			_itemInfoSlotView.Initialize(playerItem.ItemData.ItemName,
				playerItem.Quantity,
				playerItem.ItemData.Icon128,
				playerItem.ItemData.ItemTier.BackgroundPrefab128);
			_itemDescriptionView.SetText(playerItem.ItemData.DetailedDescription);

			if (playerItem.ItemData is IConsumableItem)
			{
				_consumeButtonView.Show(includeDefaultDisable: true);
			}
			else
			{
				_consumeButtonView.Hide();
			}

			_itemInfoDisabledView.Hide();
			_itemInfoEnabledView.Show(includeDefaultDisable: true);
		}

		void ClearItemInfo()
		{
			_currentPlayerItem = null;
			_itemInfoEnabledView.Hide();
			_itemInfoDisabledView.Show(includeDefaultDisable: true);
		}
	}

}
