using System;
using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using ProjectB.UI.Parts;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ProjectB.UI.Screens.BackpackScreen
{

	[Serializable]
	public class ItemInfoPanelView : UIView
	{
		[Required, SerializeField] private UIGroup _disabledPanelGroup; // 아이템이 선택되지 않았을 때 활성화되는 패널의 최상위 게임오브젝트
		[Required, SerializeField] private UIGroup _enabledPanelGroup; // 아이템이 선택되었을 때 활성화되는 패널의 최상위 게임오브젝트
		[Required, SerializeField] private TextMeshProUGUI _itemNameText;
		[Required, SerializeField] private ItemSlot _itemVisual; // 아이콘과 배경이 포함된 슬롯 오브젝트
		[Required, SerializeField] private TextMeshProUGUI _itemQuantityText;
		[Required, SerializeField] private TextMeshProUGUI _itemDescriptionText;
		[Required, SerializeField] private Button _consumeButton;
		
		public event Action ConsumeButtonClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_consumeButton.onClick.AddListener(OnConsumeButtonClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
			_consumeButton.onClick.RemoveListener(OnConsumeButtonClicked);
		}

		void OnConsumeButtonClicked()
		{
			ConsumeButtonClicked?.Invoke();
		}

		public void SetItemNameText(string itemName)
		{
			if (_itemNameText != null)
			{
				_itemNameText.text = itemName;
			}
		}
		
		public void SetItemQuantityText(int quantity)
		{
			if (_itemQuantityText != null)
			{
				_itemQuantityText.text = quantity.ToString();
			}
		}
		
		public void SetItemDescriptionText(string description)
		{
			if (_itemDescriptionText != null)
			{
				_itemDescriptionText.text = description;
			}
		}
		
		public void SetConsumeButtonActive(bool active)
		{
			if (_consumeButton != null)
			{
				_consumeButton.gameObject.SetActive(active);
			}
		}
		
		public void SetDisabledPanelActive(bool active)
		{
			if (active)
			{
				_disabledPanelGroup.Show();
			}
			else
			{
				_disabledPanelGroup.Hide();
			}
		}
		
		public void SetEnabledPanelActive(bool active)
		{
			if (active)
			{
				_enabledPanelGroup.Show();
			}
			else
			{
				_enabledPanelGroup.Hide();
			}
		}


		public override ValidationMethod GetValidationMethod(ValidationMethod chain)
		{
			return base.GetValidationMethod(chain)
				.Register("DisabledPanelTopElement 할당", () => _disabledPanelGroup != null)
				.Register("EnabledPanelTopElement 할당", () => _enabledPanelGroup != null)
				.Register("ItemNameText 할당", () => _itemNameText != null)
				.Register("ItemQuantityText 할당", () => _itemQuantityText != null)
				.Register("ItemDescriptionText 할당", () => _itemDescriptionText != null)
				.Register("ConsumeButton 할당", () => _consumeButton != null);
		}
	}

}