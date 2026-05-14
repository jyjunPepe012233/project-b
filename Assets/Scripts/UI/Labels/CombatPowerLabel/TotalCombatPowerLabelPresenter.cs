using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using ProjectB.UI.Labels.Common;
using UnityEngine;

namespace ProjectB.UI.Labels.CombatPowerLabel
{

	public class TotalCombatPowerLabelPresenter : UIPresenter<JustTextLabelView>
	{
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;

		protected override void InitializeView()
		{
			base.InitializeView();
			view.SetText(_playerDataServicePortInstaller.Port.GetTotalCombatPower().ToString());
		}
	}

}