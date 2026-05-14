using System;
using System.Collections.Generic;
using ProjectB.Data.Static.Shop;
using ProjectB.UI.Buttons.ShopItemButton;
using ProjectB.UI.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Lists.ShopItemButtonList
{

	[Serializable]
	public class ShopItemButtonListView : UIView
	{
		[SerializeField] private Transform _contentParent;
		[SerializeField] private ShopItemButtonComponent _buttonPrefab;

		private readonly List<ShopItemButtonComponent> _buttonInstances = new();
		
		public void UpdateShopItemButton(IEnumerable<IShopItem> shopItems)
		{
			foreach (var button in _buttonInstances)
				Object.Destroy(button.gameObject);
			_buttonInstances.Clear();

			foreach (var shopItem in shopItems)
			{
				var button = Object.Instantiate(_buttonPrefab, _contentParent);
				button.InitializeShopItemData(shopItem);
				_buttonInstances.Add(button);
			}
		}
	}

}