using ProjectB.UI.Core;
using ProjectB.UI.Views.Label;
using UnityEngine;

namespace ProjectB.UI.Views.Misc
{
	// 단순히 6개의 IntValueLabelView를 묶어서 관리하는 편의성 뷰임.
	
	public class StatusSetView : UIView
	{
		[SerializeField] private IntValueLabelView _hpLabel;
		[SerializeField] private IntValueLabelView _spLabel;
		[SerializeField] private IntValueLabelView _physicalAttackLabel;
		[SerializeField] private IntValueLabelView _magicalAttackLabel;
		[SerializeField] private IntValueLabelView _physicalDefenseLabel;
		[SerializeField] private IntValueLabelView _magicalDefenseLabel;
		
		public void Initialize(int hp, int sp, int physicalAttack, int magicalAttack, int physicalDefense, int magicalDefense)
		{
			SetHp(hp);
			SetSp(sp);
			SetPhysicalAttack(physicalAttack);
			SetMagicalAttack(magicalAttack);
			SetPhysicalDefense(physicalDefense);
			SetMagicalDefense(magicalDefense);
		}
		
		public void SetHp(int hp)
		{
			if (_hpLabel != null)
			{
				_hpLabel.SetValue(hp);
			}
		}
		
		public void SetSp(int sp)
		{
			if (_spLabel != null)
			{
				_spLabel.SetValue(sp);
			}
		}
		
		public void SetPhysicalAttack(int physicalAttack)
		{
			if (_physicalAttackLabel != null)
			{
				_physicalAttackLabel.SetValue(physicalAttack);
			}
		}
		
		public void SetMagicalAttack(int magicalAttack)
		{
			if (_magicalAttackLabel != null)
			{
				_magicalAttackLabel.SetValue(magicalAttack);
			}
		}
		
		public void SetPhysicalDefense(int physicalDefense)
		{
			if (_physicalDefenseLabel != null)
			{
				_physicalDefenseLabel.SetValue(physicalDefense);
			}
		}
		
		public void SetMagicalDefense(int magicalDefense)
		{
			if (_magicalDefenseLabel != null)
			{
				_magicalDefenseLabel.SetValue(magicalDefense);
			}
		}
	}

}