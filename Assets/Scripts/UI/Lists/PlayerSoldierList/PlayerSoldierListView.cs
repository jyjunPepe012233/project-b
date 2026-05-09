using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.UI.Components;
using ProjectB.UI.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Lists.PlayerSoldierList
{

	[Serializable]
	public class PlayerSoldierListView : UIView
	{
		[SerializeField] private Transform _contentParent;
		[SerializeField] private PlayerSoldierCard _cardPrefab;

		private readonly List<PlayerSoldierCard> _cardInstances = new();
		
		public void UpdatePlayerSoldiers(IEnumerable<(IReadOnlyPlayerSoldier playerSoldier, ISoldierData soldierData)> data)
		{
			foreach (var card in _cardInstances)
				Object.Destroy(card.gameObject);
			_cardInstances.Clear(); 

			foreach (var i in data)
			{
				var card = Object.Instantiate(_cardPrefab, _contentParent);
				card.ApplyPlayerSoldierData(i.playerSoldier);
				card.ApplySoldierData(i.soldierData);
				_cardInstances.Add(card);
			}
		}
	}

}