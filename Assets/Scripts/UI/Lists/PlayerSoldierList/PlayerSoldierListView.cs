using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.UI.Core;
using ProjectB.UI.Parts;
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
		
		public void UpdatePlayerSoldiers(IEnumerable<IReadOnlyPlayerSoldier> playerSoldiers)
		{
			foreach (var card in _cardInstances)
				Object.Destroy(card.gameObject);
			_cardInstances.Clear(); 

			foreach (var i in playerSoldiers)
			{
				var card = Object.Instantiate(_cardPrefab, _contentParent);
				card.ApplyPlayerSoldierData(i);
				card.ApplySoldierData(i.SoldierData);
				_cardInstances.Add(card);
			}
		}
	}

}