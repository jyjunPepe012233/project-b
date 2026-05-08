using System;
using UnityEngine;

namespace ProjectB.UI.Core
{

	[Serializable]
	public abstract class UIView : IDisposable
	{
		[SerializeField] private GameObject _topElement;

		public bool IsShowing => _topElement.activeSelf;

		public virtual void RegisterUICallbacks()
		{
		
		}

		public virtual void Dispose()
		{
		
		}
	
		public virtual void Show()
		{
			_topElement?.SetActive(true);
		}
	
		public virtual void Hide()
		{
			_topElement?.SetActive(false);
		}
	}

}
