using System;
using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Views.Buttons
{

	[Serializable]
	public class ButtonView : UIView
	{
		[Required, SerializeField] private Button _button;
	
		public event Action ButtonClicked;

		protected override void OnSetupUICallbacks()
		{
			base.OnSetupUICallbacks();
			_button.onClick.AddListener(OnButtonClicked);
		}

		protected override void OnDisposeUICallbacks()
		{
			base.OnDisposeUICallbacks();
			_button.onClick.RemoveListener(OnButtonClicked);
		}

		private void OnButtonClicked()
		{
			ButtonClicked?.Invoke();
		}


		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("Button 할당", () => _button != null);
		}
	}
}
