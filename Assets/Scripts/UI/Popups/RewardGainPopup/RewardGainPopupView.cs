using System;
using System.Collections.Generic;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.UI.Components;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Popups.RewardGainPopup
{

	[Serializable]
	public class RewardGainPopupView : UIView
	{
		[SerializeField] private PlayableDirector _openAnimDirector;
		[SerializeField] private Button _backgroundClickArea;
		[SerializeField] private Transform _itemCardsContent;
		[SerializeField] private ItemSlot _itemCardPrefab;

		private readonly List<ItemSlot> _itemCardInstances = new();
		
		public event Action BackgroundClickAreaClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_backgroundClickArea.onClick.AddListener(OnBackgroundClickAreaClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
			_backgroundClickArea.onClick.RemoveListener(OnBackgroundClickAreaClicked);
		}
		
		void OnBackgroundClickAreaClicked()
		{
			BackgroundClickAreaClicked?.Invoke();
		}

		public void ClearItemCards()
		{
			foreach (var i in _itemCardInstances)
			{
				Object.Destroy(i.gameObject);
			}
			_itemCardInstances.Clear();
		}

		public void AddItemCard(IItemData itemData, int quantity)
		{
			var instance = Object.Instantiate(_itemCardPrefab, _itemCardsContent);
			instance.SetItemInfo(itemData, quantity);
			_itemCardInstances.Add(instance);
		}
		
		public void PlayPopupAnimation()
		{
			_openAnimDirector.Stop();
			_openAnimDirector?.Play();
		}
	}

}