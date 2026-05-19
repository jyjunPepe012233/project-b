using System;
using AssetValidator;
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
		private UIGroup _uiGroup;

		public bool IsShowing => _uiGroup.IsShowing;

		public virtual void RegisterUICallbacks()
		{
		
		}

		public virtual void Dispose()
		{
		
		}
	
		public virtual void Show()
		{
			_uiGroup.Show();
		}
	
		public virtual void Hide()
		{
			_uiGroup.Hide();
		}


		public virtual ValidationMethod GetValidationMethod(ValidationMethod chain)
		{
			return chain
				.Register("UIGroup 할당", () => _uiGroup != null);
		}
	}

}
