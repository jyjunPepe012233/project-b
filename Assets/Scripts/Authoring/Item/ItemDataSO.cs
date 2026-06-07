using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Authoring.Item
{

	public abstract class ItemDataSO : UnityEngine.ScriptableObject, IItemData
	{
		[SerializeField] private string _itemId;
		public string ItemId => _itemId; 
		
		[SerializeField] private string _itemName;
		public string ItemName => _itemName;

		[TextArea(3, 10), SerializeField] private string _detailedDescription;
		public string DetailedDescription => _detailedDescription;
		
		[SerializeField] private Sprite _icon128;
		public Sprite Icon128 => _icon128;

		[SerializeField] private ItemTierDataSO _itemTier;
		public IItemTierData ItemTier => _itemTier;
		
		// 추상 프로퍼티. 이 클래스를 상속하는 클래스에서는 반드시 이 프로퍼티를 구현해야 함
		// 가능하면 코드 내에서 본 프로퍼티의 반환 값을 정의하여 enum 설정을 헷갈리는 문제를 방지할 것.
		// 예: ConsumableItemSO 클래스에서는 Category => ItemCategory.Consumable과 같이 반환 값을 정의함
		public abstract ItemCategory Category { get; }
	}

}