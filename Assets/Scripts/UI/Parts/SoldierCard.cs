using ProjectB.Data.Static.Soldier;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectB.UI.Components
{

	public class SoldierCard : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _soldierNameText;
		[SerializeField] private Transform _soldierDisplayParent;
		[SerializeField] private SimpleIcon _roleIcon;
		[SerializeField] private SimpleIcon _styleIcon;

		[SerializeField] private UnityEvent<ISoldierData> _soldierDataAppliedEvent; 

		private GameObject _displaySoldier;
		
		public void ApplySoldierData(ISoldierData soldierData)
		{
			if (_soldierNameText)
			{
				_soldierNameText.text = soldierData.SoldierName;
			}

			if (_soldierDisplayParent)
			{
				if (_displaySoldier != null)
				{
					Destroy(_displaySoldier);
				}

				_displaySoldier = Instantiate(
					soldierData.CardDisplaySetting.DisplayedSoldierPrefab,
					_soldierDisplayParent
				);
			}

//			if (_roleIcon)
//			{
//				_roleIcon.SetIcon(soldierData.Role.Icon64);
//				_roleIcon.SetBackgroundColor(soldierData.Role.Color);
//			}

//			if (_styleIcon)
//			{
//				_styleIcon.SetIcon(soldierData.Spirit.Icon64);
//				_styleIcon.SetBackgroundColor(soldierData.Spirit.Color);
//			}
			
			_soldierDataAppliedEvent.Invoke(soldierData);
		}
	}

}