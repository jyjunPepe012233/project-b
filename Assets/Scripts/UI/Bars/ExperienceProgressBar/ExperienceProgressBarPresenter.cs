using ProjectB.Data.Runtime.Player;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Bars.Common;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Bars.ExperienceProgressBar
{

	public class ExperienceProgressBarPresenter : UIPresenter<IntegerSliderProgressView>
	{
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;
		[SerializeField] private PlayerLevelUpSettingInstaller _playerLevelUpSettingInstaller;

		protected override void InitializeView()
		{
			base.InitializeView();
			IReadOnlyPlayerData playerData = _playerDataServicePortInstaller.Port.GetPlayerData();
			view.SetValue(playerData.Experience);
			view.SetMaxValue(_playerLevelUpSettingInstaller.Port.GetLevelUpExpOfLevel(playerData.Level));
		}
	}

}