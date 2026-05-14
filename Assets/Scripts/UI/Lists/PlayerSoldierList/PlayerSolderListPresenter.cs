using System;
using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Lists.PlayerSoldierList
{

	public class PlayerSolderListPresenter : UIPresenter<PlayerSoldierListView>
	{
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;

		protected override void InitializeView()
		{
			base.InitializeView();
			
			view.UpdatePlayerSoldiers(_playerDataServicePortInstaller.Port.GetPlayerData().Soldiers);
		}
	}

}