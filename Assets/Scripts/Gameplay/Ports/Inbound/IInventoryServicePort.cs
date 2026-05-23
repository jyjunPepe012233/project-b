using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IInventoryServicePort
	{
		public event Action InventoryUpdated;
		
		IReadOnlyList<IReadOnlyPlayerItem> Items { get; }
	}

}