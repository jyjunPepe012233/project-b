using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Views.Label
{

	public class StatusCompareView : UIView
	{
		[Required, SerializeField] private TextMeshProUGUI _currentValueText;
		[Required, SerializeField] private TextMeshProUGUI _upgradedValueText;
		
		public void SetStatusCompare(int currentValue, int upgradedValue)
		{
			_currentValueText.text = currentValue.ToString();
			_upgradedValueText.text = upgradedValue.ToString();
		}

		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("CurrentValue 텍스트", () => _currentValueText != null)
				.Register("UpgradedValue 텍스트", () => _upgradedValueText != null);
		}
	}

}