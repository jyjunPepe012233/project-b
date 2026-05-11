using ProjectB.Data.Static.Item;

namespace ProjectB.Data.Types
{

	public struct EquipmentCraftMaterial
	{
		public IEquipmentMaterialItem material;
		
		public int amount;
		
		public EquipmentCraftMaterial(IEquipmentMaterialItem material, int amount)
		{
			this.material = material;
			this.amount = amount;
		}
	}

}