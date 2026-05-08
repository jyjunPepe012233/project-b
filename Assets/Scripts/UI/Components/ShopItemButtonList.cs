using System;
using System.Collections.Generic;
using ProjectB.Data.Static.ShopItem;
using ProjectB.UI.Buttons.ShopItemButton;
using UnityEngine;

namespace ProjectB.UI.Components
{

	public class ShopItemButtonList : MonoBehaviour
	{
		[SerializeField] private Transform _contentRoot;
		[SerializeField] private ShopItemButtonComponent _buttonPrefab;

		private readonly List<ShopItemButtonComponent> _buttonInstances = new();


		public void InitializeAllItems(IReadOnlyList<IShopItem> shopItems)
		{
			foreach (var button in _buttonInstances)
			{
				Destroy(button.gameObject);
			}
			_buttonInstances.Clear();
			
			
			for (int i = 0; i < shopItems.Count; i++)
			{
				var button = Instantiate(_buttonPrefab, _contentRoot);
				button.InitializeShopItemData(shopItems[i]);
				_buttonInstances.Add(button);
			}
		}
	}

}
