using TMPro;
using UnityEngine;

namespace ProjectB.UI.Parts
{

	public class SoldierStatusUpgradeItem : SoldierStatusItem
	{
		[Header("Upgrade Item")]
		[SerializeField] private TextMeshProUGUI _upgradeValueText;
		
		public void SetUpgradeValue(int upgradeValue)
		{
			_upgradeValueText.text = upgradeValue.ToString();
		}
	}

}