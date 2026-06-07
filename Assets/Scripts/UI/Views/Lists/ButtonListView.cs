using ProjectB.UI.Collections;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;
using UnityEngine;

namespace ProjectB.UI.Views.Lists
{

	public class ButtonListView : UIView
	{
		[SerializeField] private RectTransform _content;

		private ComponentPrefabPool<ButtonView> _buttonPool;

		public void Initialize(ButtonView buttonPrefab, int initialCapacity = 0)
		{
			_buttonPool = new ComponentPrefabPool<ButtonView>(_content, buttonPrefab, initialCapacity);
		}

		public ButtonView CreateButton()
		{
			return _buttonPool.Load();
		}

		public void ClearButtons()
		{
			_buttonPool.UnloadAll();
		}
	}

}
