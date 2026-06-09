using System.Linq;
using ProjectB.Core.Supports;
using ProjectB.Data.Static.Soldier;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Inbound.Ports.Soldier;
using ProjectB.Gameplay.Internal.Ports.Overlay;
using ProjectB.Gameplay.Outbound.Ports.Player;

namespace ProjectB.Gameplay.Inbound.Implements.Soldier
{

	public class SoldierDetailService : ISoldierDetailService
	{
		private readonly IOverlayManager _overlayManager;
		private readonly ISoldierDetailOverlayController _soldierDetailOverlayController;
		private readonly IHoldPlayerSessionPort _holdPlayerSessionPort;
		
		private readonly SoldierDetailEvents _soldierDetailEvents;

		public SoldierDetailService(IOverlayManager overlayManager,
			ISoldierDetailOverlayController soldierDetailOverlayController,
			IHoldPlayerSessionPort holdPlayerSessionPort,
			SoldierDetailEvents soldierDetailEvents)
		{
			_overlayManager = overlayManager;
			_soldierDetailOverlayController = soldierDetailOverlayController;
			_holdPlayerSessionPort = holdPlayerSessionPort;
			_soldierDetailEvents = soldierDetailEvents;
		}

		public void ShowSoldierDetail(ISoldierData soldierData)
		{
			var playerData = _holdPlayerSessionPort.GetPlayerSession().PlayerData;
			var playerSoldier = playerData.Soldiers.FirstOrDefault(s => s.SoldierData == soldierData);

			_soldierDetailEvents.SelectSoldier?.Invoke(playerSoldier);
			CoroutineHandler.StartAndAdd(_overlayManager.Open(_soldierDetailOverlayController));
		}
	}

}