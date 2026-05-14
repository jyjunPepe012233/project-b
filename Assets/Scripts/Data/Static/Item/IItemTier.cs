using UnityEngine;

namespace ProjectB.Data.Static.Item
{

	public interface IItemTierData
	{
		string ItemTierName { get; }
		
		int ItemTierLevel { get; }

		GameObject BackgroundPrefab128 { get; }
	}

}