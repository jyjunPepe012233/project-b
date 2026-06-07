using System.Collections.Generic;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Shop;
using UnityEngine;

namespace ProjectB.Authoring.Shop
{

	[CreateAssetMenu(menuName = "Project B/Shop/Shop Setting")]
	public class ShopSettingSO : UnityEngine.ScriptableObject, IShopSetting
	{
		[SerializeField] private InterfaceRefs<IShopPage> _shopPages;
		public IReadOnlyList<IShopPage> ShopPages => _shopPages.Value;
	}

}