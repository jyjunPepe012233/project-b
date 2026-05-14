using System;
using System.Collections;
using System.Linq;
using ProjectB.Core.Supports;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class SoldierDetailService : ISoldierDetailServicePort
	{
		private readonly ILoadSoldierDetailScreenPort _loadSoldierDetailScreenPort;
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		
		public event Action<IReadOnlyPlayerSoldier> SoldierDataUpdateCallback;
		
		public SoldierDetailService(ILoadSoldierDetailScreenPort loadSoldierDetailScreenPort, IPlayerSessionHolderPort playerSessionHolderPort)
		{
			_loadSoldierDetailScreenPort = loadSoldierDetailScreenPort;
			_playerSessionHolderPort = playerSessionHolderPort;
		}

		public void ShowSoldierDetail(ISoldierData soldierData)
		{
			CoroutineHandler.StartAndAdd(ShowSoldierDetailRoutine(soldierData));
		}
		
		IEnumerator ShowSoldierDetailRoutine(ISoldierData soldierData)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			IReadOnlyPlayerSoldier playerSoldier = playerData.Soldiers.FirstOrDefault(s => s.SoldierData == soldierData);

			if (playerSoldier != null)
			{
				yield return _loadSoldierDetailScreenPort.Load(playerSoldier);
				SoldierDataUpdateCallback?.Invoke(playerSoldier);
			}
			else
			{
				Debug.LogError("플레이어가 보유하지 않은 병사의 정보를 조회하려고 시도했습니다. SoldierId: " + soldierData.SoldierId);
			}
		}
	}

}