using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Item
{

	[CreateAssetMenu(fileName = "Equipment Item", menuName = "Project B/Item/Equipment Item")]
	public class EquipmentItemSO : ItemDataSO, IEquipmentItem
	{
		// SO 설정 실수를 방지하기 위해 코드 내에서 카테고리를 정의하였음
		public override ItemCategory Category => ItemCategory.Equipment;
		
		
	}

}