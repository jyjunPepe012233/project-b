using System.Linq;
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
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;

		private ItemCategory _currentCategory;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			BackpackNavigateButtonEvents.Clicked += OnNavigateButtonClicked;
			
			view.ItemListSlotClicked += OnItemListSlotClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			BackpackNavigateButtonEvents.Clicked -= OnNavigateButtonClicked;

			view.ItemListSlotClicked -= OnItemListSlotClicked;
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
			var playerItems = _playerDataServicePortInstaller.Port.GetPlayerData().Items;
			var playerItem = playerItems.FirstOrDefault(item => item.ItemData == itemData);
			if (playerItem != null)
			{
				view.UpdateItemInfoPanel(playerItem);
				view.SetItemInfoPanelDisabledPanelActive(false);
				view.SetItemInfoPanelEnabledPanelActive(true);
			}
		}
		
		void OpenPage(ItemCategory category)
		{
			_currentCategory = category;

			// 아이템 리스트 초기화
			var playerItems = _playerDataServicePortInstaller.Port.GetPlayerData().Items;
			var categoryItems = playerItems.Where(item => item.ItemData.Category == category);
			view.UpdateItemList(categoryItems);
			
			// 아이템 상세 정보 패널을 비활성화 상태로 바꿈
			view.SetItemInfoPanelDisabledPanelActive(true);
			view.SetItemInfoPanelEnabledPanelActive(false);
		}
	}

}