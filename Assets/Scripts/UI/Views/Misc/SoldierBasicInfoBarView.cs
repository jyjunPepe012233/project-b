using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Common;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Views.Misc
{

	public class SoldierBasicInfoBarView : UIView
	{
		[Required, SerializeField] private TextMeshProUGUI _soldierNameText;
		[Required, SerializeField] private IconView _spiritIconView;
		[Required, SerializeField] private IconView _atackTypeIconView;
		[Required, SerializeField] private IconView _positionIconView;
		[Required, SerializeField] private IconView _roleIconView;
		
		public void Initialize(string soldierName,
			GameObject spiritIconPrefab,
			GameObject attackTypeIconPrefab,
			GameObject positionIconPrefab,
			GameObject roleIconPrefab)
		{
			SetSoldierName(soldierName);
			SetSpiritIcon(spiritIconPrefab);
			SetAttackTypeIcon(attackTypeIconPrefab);
			SetPositionIcon(positionIconPrefab);
			SetRoleIcon(roleIconPrefab);
		}
		
		public void SetSoldierName(string name)
		{
			_soldierNameText.text = name;
		}
		
		public void SetSpiritIcon(GameObject iconPrefab)
		{
			_spiritIconView.SetIcon(iconPrefab);
		}
		
		public void SetPositionIcon(GameObject iconPrefab)
		{
			_positionIconView.SetIcon(iconPrefab);
		}
		
		public void SetAttackTypeIcon(GameObject iconPrefab)
		{
			_atackTypeIconView.SetIcon(iconPrefab);
		}
		
		public void SetRoleIcon(GameObject iconPrefab)
		{
			_roleIconView.SetIcon(iconPrefab);
		}

		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("SoldierNameText", () => _soldierNameText != null)
				.Register("SpiritIconView", () => _spiritIconView != null)
				.Register("PositionIconView", () => _positionIconView != null)
				.Register("RoleIconView", () => _roleIconView != null);
		}
	}

}
