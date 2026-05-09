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
		[SerializeField] private SoldierDatabaseInstaller _soldierDatabaseInstaller;
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;

		protected override void InitializeView()
		{
			base.InitializeView();
			
			var soldierDatabase = _soldierDatabaseInstaller.Port;

			var tupleArray = _playerDataServicePortInstaller.Port.GetPlayerData().Soldiers.Select(playerSoldier =>
			{
				var soldierData = soldierDatabase.GetSoldierById(playerSoldier.SoldierId);
				return ((IReadOnlyPlayerSoldier)playerSoldier, soldierData); // 튜플은 다형성이 없어서 명시적으로 타입 추상화 필요
			});
			
			view.UpdatePlayerSoldiers(tupleArray);
		}
	}

}