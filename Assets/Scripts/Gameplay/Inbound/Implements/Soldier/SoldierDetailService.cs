using System;
using System.Collections;
using System.Linq;
using ProjectB.Core.Supports;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Gameplay.Inbound.Ports.Soldier;
using ProjectB.Gameplay.Internal.Ports.Overlay;
using ProjectB.Gameplay.Outbound.Ports.Player;
using UnityEngine;

namespace ProjectB.Gameplay.Inbound.Implements.Soldier
{

	public class SoldierDetailService : ISoldierDetailService
	{
		private readonly ISoldierDetailOverlayController _soldierDetailOverlayController;
		private readonly IHoldPlayerSessionPort _holdPlayerSessionPort;
		
		public event Action<IReadOnlyPlayerSoldier> SoldierDataUpdateCallback;

		public SoldierDetailService(ISoldierDetailOverlayController soldierDetailOverlayController, IHoldPlayerSessionPort holdPlayerSessionPort)
		{
			_soldierDetailOverlayController = soldierDetailOverlayController;
			_holdPlayerSessionPort = holdPlayerSessionPort;
		}

		public void ShowSoldierDetail(ISoldierData soldierData)
		{
			CoroutineHandler.StartAndAdd(ShowSoldierDetailRoutine(soldierData));
		}
		
		IEnumerator ShowSoldierDetailRoutine(ISoldierData soldierData)
		{
			var playerData = _holdPlayerSessionPort.GetPlayerSession().PlayerData;

			IReadOnlyPlayerSoldier playerSoldier = playerData.Soldiers.FirstOrDefault(s => s.SoldierData == soldierData);

			if (playerSoldier != null)
			{
				yield return _soldierDetailOverlayController.Open();
				SoldierDataUpdateCallback?.Invoke(playerSoldier);
			}
			else
			{
				Debug.LogError("플레이어가 보유하지 않은 병사의 정보를 조회하려고 시도했습니다. SoldierId: " + soldierData.SoldierId);
			}
		}
	}

}