using ProjectB.Data.Static.Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Parts
{

	public class ItemSlot : MonoBehaviour
	{
		[Header("Optionals")]
		[SerializeField] private TextMeshProUGUI _itemNameText;
		[SerializeField] private TextMeshProUGUI _itemQuantityText;
		[SerializeField] private Image _iconImage128;

		[Header("Background")]
		[SerializeField] private bool _useTierBackgroud;
		[SerializeField] private Transform _tierBackgroundParent128;

		private GameObject _iconInstance;
		
		private GameObject _backgroundInstance;
		
		public void SetItemInfo(IItemData itemData, int quantity)
		{
			if (itemData == null)
			{
				Debug.LogError("ItemData가 null입니다.");
				return;
			}
			
			if (_itemNameText != null)
			{
				_itemNameText.text = itemData.ItemName;
			}

			if (_itemQuantityText != null)
			{
				_itemQuantityText.text = quantity.ToString();
			}

			if (_iconImage128 != null)
			{
				_iconImage128.sprite = itemData.Icon128;
			}
			
			if (_useTierBackgroud)
			{
				if (_backgroundInstance != null)
				{
					Destroy(_backgroundInstance);
				}
				_backgroundInstance = Instantiate(itemData.ItemTier.BackgroundPrefab128, _tierBackgroundParent128 ?? transform);
			}
		}
	}

}