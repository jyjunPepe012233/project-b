using System;
using ProjectB.Gameplay.Events;
using ProjectB.UI.Presenters.PopUps;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Lists;
using ProjectB.UI.Views.Media;
using UnityEngine;
using UnityEngine.Playables;
using VContainer;

namespace ProjectB.Infrastructure.UI.PopUps
{

	public class RewardGainPopUpPresenterScope : UIPresenterScope<RewardGainPopUpPresenter>
	{
		[SerializeField] private TopElementView _topElementView;
		[SerializeField] private PlayableView _openAnimationPlayableView;
		[SerializeField] private PlayableAsset _openAnimationAsset;
		[SerializeField] private ButtonView _backgroundClickArea;
		[SerializeField] private ItemSlotListView _itemCardListView;
		[SerializeField] private ItemSlotView _itemCardPrefab;
		
		[Inject] private InventoryEvents _inventoryEvents;
		
		protected override RewardGainPopUpPresenter Compose()
		{
			return new RewardGainPopUpPresenter(_topElementView,
				_openAnimationPlayableView,
				_openAnimationAsset,
				_backgroundClickArea,
				_itemCardListView,
				_itemCardPrefab,
				_inventoryEvents);
		}
	}

}