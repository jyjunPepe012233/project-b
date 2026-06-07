using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Authoring.Item
{

	// 이 클래스를 상속하여 소비 아이템을 정의할 것 (예: 재화를 얻는 아이템, 아이템을 얻는 아이템, 뽑기 아이템 등)
	// 이 때, 소비 아이템을 정의한 클래스는 개발자의 의도에 따라 sealed로 설정하는 것을 추천 
	public abstract class ConsumableItemSO : ItemDataSO, IConsumableItem
	{
		public override ItemCategory Category => ItemCategory.Consumable;
	}

}