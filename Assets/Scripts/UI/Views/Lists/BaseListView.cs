using ProjectB.UI.Collections;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Views.Lists
{

	public abstract class BaseListView<TView> : UIView where TView : UIView
	{
		[SerializeField] private Transform _content;

		private ComponentPrefabPool<TView> _itemPool;

		public void Initialize(TView itemPrefab, int initialCapacity = 0)
		{
			_itemPool = new ComponentPrefabPool<TView>(_content, itemPrefab, initialCapacity);
		}

		public TView CreateItem()
		{
			return _itemPool.Load();
		}

		public void ClearItems()
		{
			_itemPool.UnloadAll();
		}
	}

}
