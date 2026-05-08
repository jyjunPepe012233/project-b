using ProjectB.Data.Runtime.Player;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Components
{

	public class SimplePlayerSoldierCard : SimpleSoldierCard
	{
		[Header("Player Soldier Card")]
		[SerializeField] private TextMeshProUGUI _levelText;
		
		public void ApplyPlayerSoldierData(IPlayerSoldier data)
		{
			if (_levelText)
			{
				_levelText.text = data.Level.ToString();
			}
		}
	}

}