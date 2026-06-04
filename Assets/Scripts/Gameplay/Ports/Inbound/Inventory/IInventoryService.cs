using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Inbound.Inventory
{

	public interface IInventoryService
	{
		IReadOnlyList<IReadOnlyPlayerItem> Items { get; }
	}

}