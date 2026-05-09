using System;
using ProjectB.Data.Types;
using ProjectB.UI.Components;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Lists.SoldierStatusList
{

	[Serializable]
	public class SoldierStatusListView : UIView
	{
		[SerializeField] private SoldierStatusItem _hpStatusItem;
		[SerializeField] private SoldierStatusItem _spStatusItem;
		[SerializeField] private SoldierStatusItem _physicalAttackStatusItem;
		[SerializeField] private SoldierStatusItem _magicalAttackStatusItem;
		[SerializeField] private SoldierStatusItem _physicalDefenseStatusItem;
		[SerializeField] private SoldierStatusItem _magicalDefenseStatusItem;

		public void SetHpStatusItem(int hp)
		{
			_hpStatusItem?.SetValue(hp);
		}
		
		public void SetSpStatusItem(int sp)
		{
			_spStatusItem?.SetValue(sp);
		}
		
		public void SetPhysicalAttackStatusItem(int physicalAttack)
		{
			_physicalAttackStatusItem?.SetValue(physicalAttack);
		}
		
		public void SetMagicalAttackStatusItem(int magicalAttack)
		{
			_magicalAttackStatusItem?.SetValue(magicalAttack);
		}
		
		public void SetPhysicalDefenseStatusItem(int physicalDefense)
		{
			_physicalDefenseStatusItem?.SetValue(physicalDefense);
		}
		
		public void SetMagicalDefenseStatusItem(int magicalDefense)
		{
			_magicalDefenseStatusItem?.SetValue(magicalDefense);
		}
	}

}
