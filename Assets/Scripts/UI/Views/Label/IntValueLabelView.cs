using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Views.Label
{

	public class IntValueLabelView : UIView
	{
		[Required, SerializeField] private TextMeshProUGUI valueText;

		public void SetValue(int value)
		{
			valueText.text = value.ToString();
		}

		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("ValueText 할당", () => valueText != null);
		}
	}

}