using System.Collections.Generic;
using AssetValidator;
using ProjectB.Core.Supports;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.View.Common
{
	
	// 최상위 요소로서, 하위 UI 전체를 조작하는 기능을 제공하는 View임
	public abstract class TopElementView : UIView
	{
		[SerializeField] private CanvasGroup _canvasGroup;

		private readonly List<UIView> _childViews = new();
		
		protected override void OnShowed()
		{
			base.OnShowed();
			_canvasGroup.SetVisible(true);
			
			// _childViews 리스트에 하위 UI 요소들을 모두 등록함
			GetComponentsInChildren<UIView>(true, _childViews);
			
			foreach (var childView in _childViews)
			{
				childView.Show();
			}
		}

		protected override void OnHided()
		{
			base.OnHided();
			_canvasGroup.SetVisible(false);
			
			GetComponentsInChildren<UIView>(true, _childViews);
			
			foreach (var childView in _childViews)
			{
				childView.Hide();
			}
		}
		
		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("CanvasGroup 할당", () => _canvasGroup != null);
		}
	}

}