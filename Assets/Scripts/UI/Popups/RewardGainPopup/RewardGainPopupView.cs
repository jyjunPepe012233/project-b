using System;
using System.Collections.Generic;
using InspectorGadgets.Attributes;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.UI.Core;
using ProjectB.UI.Parts;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Popups.RewardGainPopup
{

	[Serializable]
	public class RewardGainPopupView : UIView
	{
		[Required, SerializeField] private PlayableDirector _openAnimDirector;
		[Required, SerializeField] private Button _backgroundClickArea;
		[Required, SerializeField] private Transform _itemCardsContent;
		[Required, SerializeField] private ItemSlot _itemCardPrefab;

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