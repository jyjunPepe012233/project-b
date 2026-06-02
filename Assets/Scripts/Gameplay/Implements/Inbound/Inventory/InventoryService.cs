using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Inbound.Inventory;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound.Player;

namespace ProjectB.Gameplay.Implements.Inbound.Inventory
{
	
	public class InventoryService : IInventoryServicePort
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		private readonly IInternalInventoryServicePort _internalInventoryServicePort;

		// TODO: 메모리 큰일남. 인벤토리 더티체크 필요
		public IReadOnlyList<IReadOnlyPlayerItem> Items => _playerSessionHolderPort.GetPlayerSession().PlayerData.Items.ToArray();

		public InventoryService(IPlayerSessionHolderPort playerSessionHolderPort,
			IInternalInventoryServicePort internalInventoryServicePort)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
			_internalInventoryServicePort = internalInventoryServicePort;
		}
	}

}