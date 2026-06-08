using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Lists;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace ProjectB.UI.Views.PopUps
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

		public override void Show(bool includeDefaultDisable = false)
		{
			base.Show(includeDefaultDisable);
			
			_openAnimDirector.Stop();
			_openAnimDirector.Play();
			
			_topElementView.Show();
		}

		public override void Hide()
		{
			base.Hide();
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
			return _itemSlotListView.CreateItem();
		}
		
		public void ClearItemCards()
		{
			_itemSlotListView.ClearItems();
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
