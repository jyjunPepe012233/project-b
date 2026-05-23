using System;
using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay
{
	
	public class InventoryService : IInventoryServicePort
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		private readonly IInternalInventoryServicePort _internalInventoryServicePort;

		public event Action InventoryUpdated
		{
			add => _internalInventoryServicePort.InventoryUpdated += value;
			remove => _internalInventoryServicePort.InventoryUpdated -= value;
		}

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