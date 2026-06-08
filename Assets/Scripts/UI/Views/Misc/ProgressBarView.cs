using ProjectB.UI.Core;
using ProjectB.UI.Views.Label;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Views.Misc
{

	public class ProgressBarView : UIView
	{
		[SerializeField] private Slider _progressBar;
		[SerializeField] private TextMeshProUGUI _currenetValueText;
		[SerializeField] private TextMeshProUGUI _targetValueText;
		
		public void SetProgress(int current, int target)
		{
			float progress = (float)current / target;
			_currenetValueText.text = current.ToString();
			_targetValueText.text = target.ToString();
		}
	}

}