using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay
{
	
	public class InventoryService : IInventoryService
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;

		// TODO: 메모리 큰일남. 인벤토리 더티체크 필요
		public IReadOnlyList<IReadOnlyPlayerItem> Items => _playerSessionHolderPort.GetPlayerSession().PlayerData.Items.ToArray();

		public InventoryService(IPlayerSessionHolderPort playerSessionHolderPort)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
		}
	}

}