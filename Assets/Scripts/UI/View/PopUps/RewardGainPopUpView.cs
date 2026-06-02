using System.Collections.Generic;
using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using ProjectB.UI.View.Common;
using ProjectB.UI.View.Frames;
using ProjectB.UI.View.Lists;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace ProjectB.UI.View.PopUps
{

	public class RewardGainPopUpView : UIView
	{
		[Required, SerializeField] private TopElementView _topElementView;
		[Required, SerializeField] private PlayableDirector _openAnimDirector;
		[Required, SerializeField] private Button _backgroundClickArea;
		[Required, SerializeField] private ItemSlotListView _itemSlotListView;
		
		public void InitializeItemSlotList(ItemSlotView itemSlotPrefab, int initialCardCapacity = 0)
		{
			_itemSlotListView.Initialize(itemSlotPrefab, initialCardCapacity);
		}

		protected override void OnShowed()
		{
			base.OnShowed();
			_openAnimDirector.Stop();
			_openAnimDirector.Play();
			
			_topElementView.Show();
		}

		protected override void OnHided()
		{
			base.OnHided();
			_topElementView.Hide();
		}

		protected override void OnSetupUICallbacks()
		{
			base.OnSetupUICallbacks();
			_backgroundClickArea.onClick.AddListener(OnBackgroundClicked);
		}

		protected override void OnDisposeUICallbacks()
		{
			base.OnDisposeUICallbacks();
			_backgroundClickArea.onClick.RemoveListener(OnBackgroundClicked);
		}
		
		private void OnBackgroundClicked()
		{
			Hide();
		}

		public ItemSlotView CreateItemCard()
		{
			return _itemSlotListView.CreateSlot();
		}
		
		public void ClearItemCards()
		{
			_itemSlotListView.ClearSlots();
		}

		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("TopElementView 할당", () => _topElementView != null)
				.Register("OpenAnimDirector 할당", () => _openAnimDirector != null)
				.Register("BackgroundClickArea 할당", () => _backgroundClickArea != null)
				.Register("ItemSlotListView 할당", () => _itemSlotListView != null);
		}
	}

}