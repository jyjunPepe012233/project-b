using ProjectB.UI.Core;
using ProjectB.UI.View.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.View.Frames
{

	public class ItemSlotView : ButtonView
	{
		// 아이템 이름이나 개수가 나오지 않는 프리팹도 만들어질 수 있기 때문에
		// 각 UI 요소들을 Optional로 두고, Set 시 UI 요소가 null이라도 특별히 로그가 나오지는 않도록 함 
		
		[Header("Optional")]
		[SerializeField] private TextMeshProUGUI _itemNameText;
		[SerializeField] private TextMeshProUGUI _itemQuantityText;
		[SerializeField] private Image _iconImage128;
		[SerializeField] private Transform _tierBackgroundParent;

		private GameObject _tierBackgroundInstance;
		
		
		
		public void Initialize(string itemName,
			int quantity,
			Sprite iconSprite,
			GameObject tierBackgroundPrefab)
		{
			SetItemName(itemName);
			SetItemQuantity(quantity);
			SetIcon128(iconSprite);
			SetTierBackground(tierBackgroundPrefab);
		}
		
		public void SetItemName(string itemName)
		{
			if (_itemNameText != null)
			{
				_itemNameText.text = itemName;
			}
		}
		
		public void SetItemQuantity(int quantity)
		{
			if (_itemQuantityText != null)
			{
				_itemQuantityText.text = quantity.ToString();
			}
		}
		
		public void SetIcon128(Sprite iconSprite)
		{
			if (_iconImage128 != null)
			{
				_iconImage128.sprite = iconSprite;
			}
		}

		public void SetTierBackground(GameObject prefab)
		{
			if (_tierBackgroundParent != null)
			{
				if (_tierBackgroundInstance != null)
				{
					Destroy(_tierBackgroundInstance);
				}
				_tierBackgroundInstance = Instantiate(prefab, _tierBackgroundParent, false);
			}
		}
	}

}