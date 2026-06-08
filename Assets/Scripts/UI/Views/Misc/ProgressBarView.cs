using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Views.Misc
{

	public class ProgressBarView : UIView
	{
		[Required, SerializeField] private Slider _progressBar;
		[Required, SerializeField] private TextMeshProUGUI _currenetValueText;
		[Required, SerializeField] private TextMeshProUGUI _targetValueText;
		
		public void SetProgress(int current, int target)
		{
			float progress = (float)current / target;
			_currenetValueText.text = current.ToString();
			_targetValueText.text = target.ToString();
		}
		
		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("ProgressBar", () => _progressBar != null)
				.Register("CurrentValue 텍스트", () => _currenetValueText != null)
				.Register("TargetValue 텍스트", () => _targetValueText != null);
		}
	}

}