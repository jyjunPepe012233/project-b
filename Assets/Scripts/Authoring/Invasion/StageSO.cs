using System;
using System.Collections.Generic;
using System.Linq;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Authoring.Invasion
{

	[CreateAssetMenu(menuName = "Project B/Invasion/Stage")]
	public class StageSO : UnityEngine.ScriptableObject, IStageData
	{
		
		// 인터페이스를 직렬화할 수 없기 때문에 ItemGain 구조체를 그대로 사용할 수 없음.
		// 따라서 ItemGainEntry 클래스를 구현하여 설정을 직렬화하고,
		// ItemGain으로 변환하는 IEnumerable을 반환하는 방식을 사용함
		[Serializable]
		private class ItemGainEntry
		{
			[SerializeField] private InterfaceRef<IItemData> _item;
			[SerializeField] private int _quantity = 1;

			public ItemGain ToItemGain() => new ItemGain(_item.Value, _quantity);
		}

		
		[SerializeField] private string _stageName;
		public string StageName => _stageName;

		[SerializeField] private int _coinReward;
		public int CoinReward => _coinReward;

		[SerializeField] private List<ItemGainEntry> _itemRewards = new();
		public IEnumerable<ItemGain> ItemRewards => _itemRewards.Select(e => e.ToItemGain());
	}

}
