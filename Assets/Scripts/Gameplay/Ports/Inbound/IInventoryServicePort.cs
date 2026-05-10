using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IInventoryServicePort
	{
		IReadOnlyList<IReadOnlyPlayerItem> Items { get; }
	}

}