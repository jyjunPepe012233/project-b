using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Authoring.ScriptableObject.Item
{

	public class EquipmentMaterialItem : ItemDataSO, IEquipmentMaterialItem
	{
		// 장비 재료는 장비 카테고리에 포함
		public override ItemCategory Category => ItemCategory.Equipment;
	}

}