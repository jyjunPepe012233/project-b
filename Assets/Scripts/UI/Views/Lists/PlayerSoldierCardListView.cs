using ProjectB.UI.Collections;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Items;
using UnityEngine;

namespace ProjectB.UI.Views.Lists
{

	public class PlayerSoldierCardListView : UIView
	{
		[SerializeField] private RectTransform _content;
		
		private ComponentPrefabPool<PlayerSoldierCardView> _soldierCardPool;
		
		public void Initialize(PlayerSoldierCardView cardPrefab, int initialCapacity = 0)
		{
			_soldierCardPool = new ComponentPrefabPool<PlayerSoldierCardView>(_content, cardPrefab, initialCapacity);
		}

		public PlayerSoldierCardView CreateCard()
		{
			return _soldierCardPool.Load();
		}

		public void ClearCards()
		{
			_soldierCardPool.UnloadAll();
		}
	}

}