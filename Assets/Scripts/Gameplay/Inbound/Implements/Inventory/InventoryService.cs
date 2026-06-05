using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Inbound.Ports.Inventory;
using ProjectB.Gameplay.Internal.Ports;
using ProjectB.Gameplay.Outbound.Ports.Player;

namespace ProjectB.Gameplay.Inbound.Implements.Inventory
{
	
	public class InventoryService : IInventoryService
	{
		private readonly IHoldPlayerSessionPort _holdPlayerSessionPort;
		private readonly IInternalInventoryService _internalInventoryService;

		// TODO: 메모리 큰일남. 인벤토리 더티체크 필요
		public IReadOnlyList<IReadOnlyPlayerItem> Items => _holdPlayerSessionPort.GetPlayerSession().PlayerData.Items.ToArray();

		public InventoryService(IHoldPlayerSessionPort holdPlayerSessionPort,
			IInternalInventoryService internalInventoryService)
		{
			_holdPlayerSessionPort = holdPlayerSessionPort;
			_internalInventoryService = internalInventoryService;
		}
	}

}