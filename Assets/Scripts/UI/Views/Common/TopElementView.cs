using System.Collections.Generic;
using ProjectB.UI.Core;

namespace ProjectB.UI.Views.Common
{
	
	// 최상위 요소로서, 하위 UI 전체를 조작하는 기능을 제공하는 View임
	public class TopElementView : UIView
	{
		private readonly List<UIView> _childViews = new();
		
		protected override void OnShowed()
		{
			// _childViews 리스트에 하위 UI 요소들을 모두 등록함
			GetComponentsInChildren<UIView>(true, _childViews);
			
			foreach (var childView in _childViews)
			{
				childView.Show();
			}
		}

		protected override void OnHided()
		{
			GetComponentsInChildren<UIView>(true, _childViews);
			
			foreach (var childView in _childViews)
			{
				childView.Hide();
			}
		}
	}

}