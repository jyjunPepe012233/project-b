using TMPro;
using UnityEngine;

namespace ProjectB.UI.Components
{

	public class SimpleSoldierStatusUpgradeItem : SimpleSoldierStatusItem
	{
		[Header("Upgrade Item")]
		[SerializeField] private TextMeshProUGUI _upgradeValueText;
		
		public void SetUpgradeValue(int upgradeValue)
		{
			_upgradeValueText.text = upgradeValue.ToString();
		}
	}

}