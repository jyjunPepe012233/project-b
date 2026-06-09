using ProjectB.Data.Types;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectB.UI.Views.Misc
{
	// 단순히 6개의 IntValueLabelView를 묶어서 관리하는 편의성 뷰임.
	
	public class StatusSetView : UIView
	{
		[FormerlySerializedAs("_hpLabel")] [SerializeField] private IntValueView _hpView;
		[FormerlySerializedAs("_spLabel")] [SerializeField] private IntValueView _spView;
		[FormerlySerializedAs("_physicalAttackLabel")] [SerializeField] private IntValueView _physicalAttackView;
		[FormerlySerializedAs("_magicalAttackLabel")] [SerializeField] private IntValueView _magicalAttackView;
		[FormerlySerializedAs("_physicalDefenseLabel")] [SerializeField] private IntValueView _physicalDefenseView;
		[FormerlySerializedAs("_magicalDefenseLabel")] [SerializeField] private IntValueView _magicalDefenseView;
		
		public void Initialize(int hp, int sp, int physicalAttack, int magicalAttack, int physicalDefense, int magicalDefense)
		{
			SetHp(hp);
			SetSp(sp);
			SetPhysicalAttack(physicalAttack);
			SetMagicalAttack(magicalAttack);
			SetPhysicalDefense(physicalDefense);
			SetMagicalDefense(magicalDefense);
		}

		public void Initialize(SoldierStatus soldierStatus)
		{
			SetHp(soldierStatus.hp);
			SetSp(soldierStatus.sp);
			SetPhysicalAttack(soldierStatus.physicalAttack);
			SetMagicalAttack(soldierStatus.magicalAttack);
			SetPhysicalDefense(soldierStatus.physicalDefense);
			SetMagicalDefense(soldierStatus.magicalDefense);
		}
		
		public void SetHp(int hp)
		{
			if (_hpView != null)
			{
				_hpView.SetValue(hp);
			}
		}
		
		public void SetSp(int sp)
		{
			if (_spView != null)
			{
				_spView.SetValue(sp);
			}
		}
		
		public void SetPhysicalAttack(int physicalAttack)
		{
			if (_physicalAttackView != null)
			{
				_physicalAttackView.SetValue(physicalAttack);
			}
		}
		
		public void SetMagicalAttack(int magicalAttack)
		{
			if (_magicalAttackView != null)
			{
				_magicalAttackView.SetValue(magicalAttack);
			}
		}
		
		public void SetPhysicalDefense(int physicalDefense)
		{
			if (_physicalDefenseView != null)
			{
				_physicalDefenseView.SetValue(physicalDefense);
			}
		}
		
		public void SetMagicalDefense(int magicalDefense)
		{
			if (_magicalDefenseView != null)
			{
				_magicalDefenseView.SetValue(magicalDefense);
			}
		}
	}

}

// TODO 할 일 메모: 26.06.08.
// - 프로젝트B 제외 포폴 쓰기
// - SoldierDetailOverlay의 각 Page의 Presenter 만들기(스크립트 위치(분류)는 코덱스에게 물어보기?)