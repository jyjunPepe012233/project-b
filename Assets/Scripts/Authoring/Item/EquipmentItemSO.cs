using System;
using System.Collections.Generic;
using System.Linq;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Authoring.Item
{

	[CreateAssetMenu(fileName = "Equipment Item", menuName = "Project B/Item/Equipment Item")]
	public class EquipmentItemSO : ItemDataSO, IEquipmentItem
	{
		// EquipmentCraftMaterial 구조체를 직렬화하기 위한 클래스
		[Serializable]
		class EquipmentCraftMaterialEntry
		{
			public InterfaceRef<IEquipmentMaterialItem> material;
			public int amount;
			
			public EquipmentCraftMaterial ToEquipmentCraftMaterial()
			{
				return new EquipmentCraftMaterial
				{
					material = material.Value,
					amount = amount
				};
			}
		}
		
		
		// SO 설정 실수를 방지하기 위해 코드 내에서 카테고리를 정의하였음
		public override ItemCategory Category => ItemCategory.Equipment;
		
		[SerializeField] private EquipmentCraftMaterialEntry[] _craftMaterialEntries;
		public IEnumerable<EquipmentCraftMaterial> CraftMaterials =>
			_craftMaterialEntries.Select(e => e.ToEquipmentCraftMaterial());
	}

}