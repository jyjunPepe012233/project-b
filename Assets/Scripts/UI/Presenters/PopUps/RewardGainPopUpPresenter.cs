using System.Collections;
using System.Collections.Generic;
using ProjectB.Core.Supports;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Events;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Lists;
using ProjectB.UI.Views.Media;
using UnityEngine;
using PlayableAsset = UnityEngine.Playables.PlayableAsset;

namespace ProjectB.UI.Presenters.PopUps
{

	public class RewardGainPopUpPresenter : UIPresenter
	{
		private readonly TopElementView _topElementView;
		private readonly PlayableView _openAnimationPlayableView;
		private readonly PlayableAsset _openAnimationAsset;
		private readonly ButtonView _backgroundClickArea;
		private readonly ItemSlotListView _itemCardListView;
		private readonly ItemSlotView _itemCardPrefab;
		
		private readonly InventoryEvents _inventoryEvents;

		private readonly WaitForSeconds _createItemCardLoopDelayYield = new WaitForSeconds(0.1f);
		private Coroutine _createItemCardLoopCoroutine;

		public RewardGainPopUpPresenter(TopElementView topElementView,
			PlayableView openAnimationPlayableView,
			PlayableAsset openAnimationAsset,
			ButtonView backgroundClickArea,
			ItemSlotListView itemSlotListView,
			ItemSlotView itemCardPrefab,
			InventoryEvents inventoryEvents)
		{
			_topElementView = topElementView;
			_openAnimationPlayableView = openAnimationPlayableView;
			_openAnimationAsset = openAnimationAsset;
			_backgroundClickArea = backgroundClickArea;
			_itemCardListView = itemSlotListView;
			_itemCardPrefab = itemCardPrefab;
			_inventoryEvents = inventoryEvents;
		}

		public override void Initialize()
		{
			base.Initialize();
			_itemCardListView.Initialize(_itemCardPrefab, 10);
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_backgroundClickArea.ButtonClicked += OnBackgroundClickAreaClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_backgroundClickArea.ButtonClicked -= OnBackgroundClickAreaClicked;
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
		
		void OnBackgroundClickAreaClicked()
		{
			_topElementView.Hide();
			if (_createItemCardLoopCoroutine != null)
			{
				CoroutineHandler.Stop(_createItemCardLoopCoroutine);
			}
		}

		void OnItemAdded(IEnumerable<ItemGain> itemGain, ItemGainAction itemGainAction)
		{
			if (itemGainAction == ItemGainAction.Reward)
			{
				_topElementView.Show(true);
				
				CoroutineHandler.StartAndAdd(_openAnimationPlayableView.Play(_openAnimationAsset));
				
				// 아이템 카드 인스턴스들을 제거
				_itemCardListView.ClearItems();
				
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
				ItemSlotView card = _itemCardListView.CreateItem();
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