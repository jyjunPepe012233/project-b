using System;
using ProjectB.Data.Types;
using ProjectB.UI.Components;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Lists.SoldierStatusUpgradeList
{

	[Serializable]
	public class SoldierStatusUpgradeListView : UIView
	{
		[Header("꼭 모든 아이템을 할당하지는 않아도 됨")]
		[SerializeField] private SoldierStatusUpgradeItem _hpStatusItem;
		[SerializeField] private SoldierStatusUpgradeItem _spStatusItem;
		[SerializeField] private SoldierStatusUpgradeItem _physicalAttackStatusItem;
		[SerializeField] private SoldierStatusUpgradeItem _magicalAttackStatusItem;
		[SerializeField] private SoldierStatusUpgradeItem _physicalDefenseStatusItem;
		[SerializeField] private SoldierStatusUpgradeItem _magicalDefenseStatusItem;

		public void SetHpStatusItem(int currentHp, int nextHp)
		{
			SetStatusOfItem(_hpStatusItem, currentHp, nextHp);
		}
		
		public void SetSpStatusItem(int currentSp, int nextSp)
		{
			SetStatusOfItem(_spStatusItem, currentSp, nextSp);
		}
		
		public void SetPhysicalAttackStatusItem(int currentPhysicalAttack, int nextPhysicalAttack)
		{
			SetStatusOfItem(_physicalAttackStatusItem, currentPhysicalAttack, nextPhysicalAttack);
		}
		
		public void SetMagicalAttackStatusItem(int currentMagicalAttack, int nextMagicalAttack)
		{
			SetStatusOfItem(_magicalAttackStatusItem, currentMagicalAttack, nextMagicalAttack);
		}
		
		public void SetPhysicalDefenseStatusItem(int currentPhysicalDefense, int nextPhysicalDefense)
		{
			SetStatusOfItem(_physicalDefenseStatusItem, currentPhysicalDefense, nextPhysicalDefense);
		}
		
		public void SetMagicalDefenseStatusItem(int currentMagicalDefense, int nextMagicalDefense)
		{
			SetStatusOfItem(_magicalDefenseStatusItem, currentMagicalDefense, nextMagicalDefense);
		}

		void SetStatusOfItem(SoldierStatusUpgradeItem item, int currentStatus, int nextStatus)
		{
			if (item != null)
			{
				item.SetValue(currentStatus);
				item.SetUpgradeValue(nextStatus - currentStatus);
			}
		}
	}

}
