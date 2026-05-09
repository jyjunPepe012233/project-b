using System;
using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Static.Soldier;
using ProjectB.UI.Components;
using ProjectB.UI.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Lists.SoldierList
{

	[Serializable]
	public class SoldierListView : UIView
	{
		[SerializeField] private Transform _contentParent;
		[SerializeField] private SoldierCard _cardPrefab;

		private readonly List<SoldierCard> _cardInstances = new();
		
		public void UpdateSoldiers(IEnumerable<ISoldierData> data)
		{
			foreach (var card in _cardInstances)
				Object.Destroy(card);
			_cardInstances.Clear(); 

			foreach (var i in data)
			{
				var card = Object.Instantiate(_cardPrefab);
				card.ApplySoldierData(i);
				_cardInstances.Add(card);
			}
		}
	}

}