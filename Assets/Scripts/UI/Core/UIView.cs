using System;
using InspectorGadgets.Attributes;
using ProjectB.Core.Supports;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Core
{

	[Serializable]
	public abstract class UIView : IDisposable
	{
		[Required, SerializeField]
		private GameObject _topElement;

		[Required, SerializeField]
		private CanvasGroup _canvasGroup;

		public bool IsShowing { get; set; }

		public virtual void RegisterUICallbacks()
		{
		
		}

		public virtual void Dispose()
		{
		
		}
	
		public virtual void Show()
		{
			if (_canvasGroup != null)
			{
				IsShowing = true;
				_canvasGroup.SetVisible(true);
			}
		}
	
		public virtual void Hide()
		{
			if (_canvasGroup != null)
			{
				IsShowing = false;
				_canvasGroup.SetVisible(false);
			}
		}
	}

}
