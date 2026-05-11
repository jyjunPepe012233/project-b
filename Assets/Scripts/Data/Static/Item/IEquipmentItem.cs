using System.Collections.Generic;
using ProjectB.Data.Types;

namespace ProjectB.Data.Static.Item
{

	public interface IEquipmentItem : IItemData
	{
		IEnumerable<EquipmentCraftMaterial> CraftMaterials { get; }
	}

}