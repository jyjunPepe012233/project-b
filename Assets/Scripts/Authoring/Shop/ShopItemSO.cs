using ProjectB.Core.Types;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Static.Shop;
using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Authoring.Shop
{

	[CreateAssetMenu(fileName = "Shop Item", menuName = "Project B/Shop/Shop Item")]
	public class ShopItemSO : UnityEngine.ScriptableObject, IShopItem
	{
		[Header("Cost")]
		
		[SerializeField] private CurrencyType _currencyType;
		public CurrencyType CurrencyType => _currencyType;
		
		[SerializeField] private int _price = 100;
		public int Price => _price;
		
		[Header("Item")]
		
		[SerializeField] private InterfaceRef<IItemData> _itemData;
		public IItemData ItemData => _itemData.Value;
		
		[SerializeField] private int _quantity = 1;
		public int Quantity => _quantity;
	}

}