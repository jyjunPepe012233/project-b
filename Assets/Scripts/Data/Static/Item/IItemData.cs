using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Data.Static.Item
{

	public interface IItemData
	{
		string ItemId { get; }
		
		string ItemName { get; }
		
		Sprite Icon128 { get; }
		
		IItemTierData ItemTier { get; }
		
		ItemCategory Category { get; }
	}

}