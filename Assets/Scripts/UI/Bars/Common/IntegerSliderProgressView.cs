using System;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Bars.Common
{

	[Serializable]
	public class IntegerSliderProgressView : UIView
	{
		[SerializeField] private Slider _slider;
		[SerializeField] private TextMeshProUGUI _valueText;
		[SerializeField] private TextMeshProUGUI _maxValueText;
		
		public void SetValue(int value)
		{
			_slider.value = value;
			_valueText.text = value.ToString();
		}
		
		public void SetMaxValue(int maxValue)
		{
			_slider.maxValue = maxValue;
			_maxValueText.text = maxValue.ToString();
		}
	}

}