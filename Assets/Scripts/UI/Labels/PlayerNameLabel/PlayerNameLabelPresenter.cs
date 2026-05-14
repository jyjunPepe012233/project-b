using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using ProjectB.UI.Labels.Common;
using UnityEngine;

namespace ProjectB.UI.Labels.PlayerNameLabel
{

	public class PlayerNameLabelPresenter : UIPresenter<JustTextLabelView>
	{
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;
		
		protected override void InitializeView()
		{
			base.InitializeView();
			view.SetText(_playerDataServicePortInstaller.Port.GetPlayerData().PlayerName);
		}
	}

}