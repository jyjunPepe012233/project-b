using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Inbound.Ports.Inventory
{

	public interface IInventoryService
	{
		IReadOnlyList<IReadOnlyPlayerItem> Items { get; }
	}

}