using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Item
{

	[CreateAssetMenu(fileName = "Gain Currency Item", menuName = "Project B/Item/Gain Currency Item")]
	public sealed class GainCurrencyItemSO : ConsumableItemSO
	{
		[SerializeField] private CurrencyType _currencyType;
		public CurrencyType CurrencyType => _currencyType;
		
		[SerializeField] private int _amount = 100;
		public int Amount => _amount;
	}

}