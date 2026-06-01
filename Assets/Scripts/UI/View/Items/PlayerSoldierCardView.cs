using ProjectB.Data.Runtime.Player;
using ProjectB.UI.View.Buttons;
using ProjectB.UI.View.Common.Dictionaries;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.View.Items
{

	public class PlayerSoldierCardView : ButtonView
	{
		[SerializeField] private TextMeshProUGUI _soldierNameText;
		[SerializeField] private GameObjectDictionaryView _soldierDisplayParent;
		[SerializeField] private GameObjectDictionaryView _roleIconParent;
		[SerializeField] private GameObjectDictionaryView _spiritIconParent;
		
		public void InitializePlayerSoldierData(IReadOnlyPlayerSoldier playerSoldier)
		{
			var soldierData = playerSoldier.SoldierData;

			if (_soldierNameText)
			{
				_soldierNameText.text = soldierData.SoldierName;
			}
			
			if (_soldierDisplayParent)
			{
				var prefab = soldierData.CardDisplaySetting.DisplayedSoldierPrefab;
				_soldierDisplayParent.RegisterAndSetActiveInstance(soldierData.SoldierId, prefab);
			}

			if (_roleIconParent)
			{
				var prefab = soldierData.Role.IconPrefab64;
				_roleIconParent.RegisterAndSetActiveInstance(soldierData.Role.SoldierRoleName, prefab);
			}

			if (_spiritIconParent)
			{
				var prefab = soldierData.Spirit.IconPrefab64;
				_spiritIconParent.RegisterAndSetActiveInstance(soldierData.Spirit.SpiritName, prefab);
			}
		}
	}

}