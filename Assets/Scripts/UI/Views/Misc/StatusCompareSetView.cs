using ProjectB.Data.Types;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Label;
using UnityEngine;

namespace ProjectB.UI.Views.Misc
{
	// 단순히 6개의 기본 스테이터스에 대응되는 IntValueCompareView를 묶어서 관리하는 편의성 뷰

	public class StatusCompareSetView : UIView
	{
		[SerializeField] private IntValueCompareView _hpLabel;
		[SerializeField] private IntValueCompareView _spLabel;
		[SerializeField] private IntValueCompareView _physicalAttackLabel;
		[SerializeField] private IntValueCompareView _magicalAttackLabel;
		[SerializeField] private IntValueCompareView _physicalDefenseLabel;
		[SerializeField] private IntValueCompareView _magicalDefenseLabel;

		public void Initialize(SoldierStatus current, SoldierStatus upgraded)
		{
			SetHpCompare(current.hp, upgraded.hp);
			SetSpCompare(current.sp, upgraded.sp);
			SetPhysicalAttackCompare(current.physicalAttack, upgraded.physicalAttack);
			SetMagicalAttackCompare(current.magicalAttack, upgraded.magicalAttack);
			SetPhysicalDefenseCompare(current.physicalDefense, upgraded.physicalDefense);
			SetMagicalDefenseCompare(current.magicalDefense, upgraded.magicalDefense);
		}

		public void SetHpCompare(int current, int upgraded)
		{
			_hpLabel.SetStatusCompare(current, upgraded);
		}

		public void SetSpCompare(int current, int upgraded)
		{
			_spLabel.SetStatusCompare(current, upgraded);
		}
		
		public void SetPhysicalAttackCompare(int current, int upgraded)
		{
			_physicalAttackLabel.SetStatusCompare(current, upgraded);
		}
		
		public void SetMagicalAttackCompare(int current, int upgraded)
		{
			_magicalAttackLabel.SetStatusCompare(current, upgraded);
		}
		
		public void SetPhysicalDefenseCompare(int current, int upgraded)
		{
			_physicalDefenseLabel.SetStatusCompare(current, upgraded);
		}
		
		public void SetMagicalDefenseCompare(int current, int upgraded)
		{
			_magicalDefenseLabel.SetStatusCompare(current, upgraded);
		}
	}

}