using System;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Labels.MoraleLabel
{

	[Serializable]
	public class MoraleLabelView : UIView
	{ 
		[SerializeField] private TextMeshProUGUI _moraleText;
		[SerializeField] private TextMeshProUGUI _maxMoraleText;
		
		public void SetMoraleText(string text)
		{
			_moraleText.text = text;
		}
		
		public void SetMaxMoraleText(string text)
		{
			_maxMoraleText.text = text;
		}
	}

}