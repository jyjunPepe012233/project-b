using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Buttons.BackpackNavigateButton;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.BackpackScreen
{

	public class BackpackScreenPresenter : UIPresenter<BackpackScreenView>
	{
		[SerializeField] private InventoryServicePortInstaller _inventoryServicePortInstaller;
		[SerializeField] private ConsumeItemServicePortInstaller _consumeItemServicePortInstaller;

		private ItemCategory _currentCategory;

		private IReadOnlyPlayerItem _showingItemOnItemInfoPanel;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			BackpackNavigateButtonEvents.Clicked += OnNavigateButtonClicked;
			
			view.ItemListSlotClicked += OnItemListSlotClicked;
			view.ConsumeButtonClicked += OnConsumeButtonClicked;
			
			_inventoryServicePortInstaller.Port.InventoryUpdated += OnInventoryUpdated;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			BackpackNavigateButtonEvents.Clicked -= OnNavigateButtonClicked;

			view.ItemListSlotClicked -= OnItemListSlotClicked;
			view.ConsumeButtonClicked -= OnConsumeButtonClicked;
			
			_inventoryServicePortInstaller.Port.InventoryUpdated -= OnInventoryUpdated;
		}

		protected override void InitializeView()
		{
			base.InitializeView();
			
			// 처음 열었을 때는 소비 아이템 페이지가 보이도록 설정
			OpenPage(ItemCategory.Consumable);
		}

		void OnNavigateButtonClicked(ItemCategory category)
		{
			// 클릭한 버튼의 카테고리가 현재 페이지의 카테고리와 다르면 페이지를 전환
			if (_currentCategory != category)
			{
				OpenPage(category);
			}
		}
		
		void OnItemListSlotClicked(IItemData itemData)
		{
			var playerItems = _inventoryServicePortInstaller.Port.Items;
			var playerItem = playerItems.FirstOrDefault(item => item.ItemData == itemData);
			if (playerItem != null)
			{
				UpdateItemInfoPanel(playerItem);
			}
		}

		void OnConsumeButtonClicked()
		{
			if (_showingItemOnItemInfoPanel == null)
			{
				Debug.LogError("소비 버튼이 클릭되었지만 선택된 아이템이 없음");
				return;
			}
			_consumeItemServicePortInstaller.Port.ConsumeItem(_showingItemOnItemInfoPanel.ItemData);
		}
		
		void OnInventoryUpdated()
		{
			UpdateItemList(_currentCategory);
			
			// 인벤토리 업데이트 시, 현재 보고 있는 아이템이 인벤토리에 여전히 존재하는지 확인하고,
			// 없으면 아이템 정보 패널을 비활성화 상태로 전환
			if (_inventoryServicePortInstaller.Port.Items.All(pi => pi != _showingItemOnItemInfoPanel))
			{
				ClearItemInfoPanel();
			}
			else
			{
				UpdateItemInfoPanel(_showingItemOnItemInfoPanel);
			}
		}
		
		void OpenPage(ItemCategory category)
		{
			_currentCategory = category;
			
			UpdateItemList(category);
			ClearItemInfoPanel();
		}

		void UpdateItemList(ItemCategory category)
		{
			// 아이템 리스트 초기화
			var playerItems = _inventoryServicePortInstaller.Port.Items;
			var categoryItems = playerItems.Where(item => item.ItemData.Category == category);
			view.UpdateItemList(categoryItems);
		}

		void UpdateItemInfoPanel(IReadOnlyPlayerItem playerItem)
		{
			_showingItemOnItemInfoPanel = playerItem;
			
			view.UpdateItemInfoPanel(playerItem);
			view.SetItemInfoPanelDisabledPanelActive(false);
			view.SetItemInfoPanelEnabledPanelActive(true);
		}
		
		void ClearItemInfoPanel()
		{
			_showingItemOnItemInfoPanel = null;
			
			view.SetItemInfoPanelDisabledPanelActive(true);
			view.SetItemInfoPanelEnabledPanelActive(false);
		}
	}

}