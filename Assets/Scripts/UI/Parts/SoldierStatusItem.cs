using TMPro;
using UnityEngine;

namespace ProjectB.UI.Parts
{

	public class SoldierStatusItem : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _valueText;

		public void SetValue(int value)
		{
			_valueText.text = value.ToString();
		}
	}

}
