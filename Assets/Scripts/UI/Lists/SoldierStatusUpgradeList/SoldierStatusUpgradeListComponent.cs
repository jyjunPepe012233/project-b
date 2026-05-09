using ProjectB.Data.Types;
using ProjectB.UI.Core;

namespace ProjectB.UI.Lists.SoldierStatusUpgradeList
{

	public class SoldierStatusUpgradeListComponent : UIComponent<SoldierStatusUpgradeListView>
	{
		public void UpdateStatus(SoldierStatus currentStatus, SoldierStatus nextStatus)
		{
			view.SetHpStatusItem(currentStatus.hp, nextStatus.hp);
			view.SetSpStatusItem(currentStatus.sp, nextStatus.sp);
			view.SetPhysicalAttackStatusItem(currentStatus.physicalAttack, nextStatus.physicalAttack);
			view.SetMagicalAttackStatusItem(currentStatus.magicalAttack, nextStatus.magicalAttack);
			view.SetPhysicalDefenseStatusItem(currentStatus.physicalDefense, nextStatus.physicalDefense);
			view.SetMagicalDefenseStatusItem(currentStatus.magicalDefense, nextStatus.magicalDefense);
		}
	}

}
