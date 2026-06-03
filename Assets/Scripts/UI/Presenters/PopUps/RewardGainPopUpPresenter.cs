using System.Collections;
using System.Collections.Generic;
using ProjectB.Core.Supports;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Events;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.PopUps;
using UnityEngine;

namespace ProjectB.UI.Presenters.PopUps
{
	// TODO 26.06.02. 00시 26분 할 일 메모
	// 지금 UI 구조 리팩토링 하고 있음...
	// RewardGainPopUp을 왜 지금 만들고 있는지는 모르겠는데, 일단 다 View랑 함께 다 구현하고 나서
	// TitleScreen -> Home -> ShopScreen -> RewardGainPopUp 흐름을 가장 먼저 테스트해야 할 것 같음
	// 그 뒤로는 모든 UI 리팩토링 하고, 새로운 기능과 UI들 추가로 개발해나가면 될 듯
	
	// 그리고 포트폴리오에, 과거 경험을 바탕으로 UI 구조 개선 페이지는 1장으로 줄이는 것도 고려해보면 좋을 듯
	// 일단 내 장점이 UI 하나만 있는 것도 아니고, 트릭컬에 맞는 다양한 기술들을 배운 것도 나름 장점이니까
	// Addressable 기초 이해도 같은 것도 어필하면 오히려 더 가산점 받을 수 있지 않을까?
	
	// UI 구조 리팩토링은 이미 고민 많이 해서 크게 바꾼거니까, 시간 너무 많이 쓰지 말고 구현부터 다 하기!!
	// 이 프로젝트 다 끝내면 Unity 데모 프로젝트에서 기능을 확장하는 것도 고려해보면 좋을 듯
	

	public class RewardGainPopUpPresenter : UIPresenter
	{
		private readonly RewardGainPopUpView _rewardGainPopUpView;
		private readonly ItemSlotView _itemCardPrefab;
		private readonly InventoryEvents _inventoryEvents;

		private readonly WaitForSeconds _createItemCardLoopDelayYield = new WaitForSeconds(0.1f);
		private readonly Coroutine _createItemCardLoopCoroutine;

		public RewardGainPopUpPresenter(RewardGainPopUpView rewardGainPopUpView,
			ItemSlotView itemCardPrefab,
			InventoryEvents inventoryEvents)
		{
			_rewardGainPopUpView = rewardGainPopUpView;
			_itemCardPrefab = itemCardPrefab;
			_inventoryEvents = inventoryEvents;
		}

		public override void Initialize()
		{
			base.Initialize();
			_rewardGainPopUpView.InitializeItemSlotList(_itemCardPrefab, 10);
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_inventoryEvents.ItemAdded += OnItemAdded;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_inventoryEvents.ItemAdded -= OnItemAdded;
		}

		void OnItemAdded(IEnumerable<ItemGain> itemGain, ItemGainAction itemGainAction)
		{
			if (itemGainAction == ItemGainAction.Reward)
			{
				_rewardGainPopUpView.Show();
				
				// 아이템 카드 인스턴스들을 제거
				_rewardGainPopUpView.ClearItemCards();
				
				// 아이템 카드 생성 애니메이션 시작
				if (_createItemCardLoopCoroutine != null)
				{
					CoroutineHandler.Stop(_createItemCardLoopCoroutine);
				}
				CoroutineHandler.StartAndAdd(CreateItemCardLoop(itemGain));
			}
		}

		IEnumerator CreateItemCardLoop(IEnumerable<ItemGain> itemGains)
		{
			foreach (var itemGain in itemGains)
			{
				ItemSlotView card = _rewardGainPopUpView.CreateItemCard();
				card.Initialize(
					itemName: itemGain.item.ItemName,
					quantity: itemGain.quantity,
					iconSprite: itemGain.item.Icon128,
					tierBackgroundPrefab: itemGain.item.ItemTier.BackgroundPrefab128
				);
				
				yield return _createItemCardLoopDelayYield;
			}
		}
	}

}