using TMPro;
using UnityEngine;

namespace ProjectB.UI.Components
{

	public class SimpleSoldierStatusItem : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _valueText;

		public void SetValue(int value)
		{
			_valueText.text = value.ToString();
		}
	}

}
