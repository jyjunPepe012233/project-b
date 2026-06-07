using System.Collections.Generic;
using System.Linq;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Item;
using UnityEngine;

namespace ProjectB.Authoring.Item
{

	[CreateAssetMenu(menuName = "Project B/Item/Item Database")]
	public class ItemDatabaseSO : UnityEngine.ScriptableObject, IItemDatabase
	{
		[SerializeField] private InterfaceRefs<IItemData> _items;
		public IReadOnlyList<IItemData> Items => _items.Value;

		private readonly Dictionary<string, IItemData> _idToDataTable = new();

		public IItemData GetItemById(string itemId)
		{
			if (_idToDataTable.TryGetValue(itemId, out var cached))
			{
				return cached;
			}

			var found = _items.Value.FirstOrDefault(item => item.ItemId == itemId);
			_idToDataTable.Add(itemId, found);

			return found;
		}
	}

}
