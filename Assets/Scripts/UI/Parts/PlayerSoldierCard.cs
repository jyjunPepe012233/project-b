using ProjectB.Data.Runtime.Player;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Components
{

	public class PlayerSoldierCard : SoldierCard
	{
		[Header("Player Soldier Card")]
		[SerializeField] private TextMeshProUGUI _levelText;
		
		public void ApplyPlayerSoldierData(IReadOnlyPlayerSoldier data)
		{
			if (_levelText)
			{
				_levelText.text = data.Level.ToString();
			}
		}
	}

}