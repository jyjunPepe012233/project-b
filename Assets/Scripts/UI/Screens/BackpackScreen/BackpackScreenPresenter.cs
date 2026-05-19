using System;
using System.Collections.Generic;
using AssetValidator;
using ProjectB.Data.Runtime.Player;
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
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			BackpackNavigateButtonEvents.Clicked -= OnNavigateButtonClicked;
		}

		protected override void InitializeView()
		{
			base.InitializeView();
			
			// 처음 열었을 때는 소비 아이템 페이지가 보이도록 설정
			OpenPage(ItemCategory.Consumable);
			UpdatePage(_currentCategory);
		}

		void OnNavigateButtonClicked(ItemCategory category)
		{
			// 클릭한 버튼의 카테고리가 현재 페이지의 카테고리와 다르면 페이지를 전환
			if (_currentCategory != category)
			{
				OpenPage(category);
			}

			UpdatePage(category);
		}
		
		void OpenPage(ItemCategory category)
		{
			_currentCategory = category;

			view.SetVisibleConsumablePage(category == ItemCategory.Consumable);
			view.SetVisibleEquipmentPage(category == ItemCategory.Equipment);
		}
		
		void UpdatePage(ItemCategory itemCategory)
		{
			// 특정 페이지를 업데이트하는 메서드와 페이지의 카테고리를 입력하여
			// itemCategory와 페이지의 카테고리가 일치하면 해당 페이지의 아이템 리스트를 업데이트하는 메서드
			void UpdateIfCategoryMatches(Action<IEnumerable<IPlayerItem>> updateAction, ItemCategory pageCategory)
			{
				if (itemCategory != pageCategory) return;
				
				var playerData = _playerDataServicePortInstaller.Port.GetPlayerData();
				updateAction?.Invoke(playerData.Items);
			}
			
			// 지역 메서드를 사용하여 다양한 페이지를 간단하게 업데이트
			UpdateIfCategoryMatches(view.UpdateConsumablePage, ItemCategory.Consumable);
			UpdateIfCategoryMatches(view.UpdateEquipmentPage, ItemCategory.Equipment);
		}
	}

}