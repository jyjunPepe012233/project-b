using ProjectB.Data.Types;
using ProjectB.UI.Core;

namespace ProjectB.UI.Lists.SoldierStatusList
{

	public class SoldierStatusListComponent : UIComponent<SoldierStatusListView>
	{
		public void UpdateStatus(SoldierStatus status)
		{
			view.SetHpStatusItem(status.hp);
			view.SetSpStatusItem(status.sp);
			view.SetPhysicalAttackStatusItem(status.physicalAttack);
			view.SetMagicalAttackStatusItem(status.magicalAttack);
			view.SetPhysicalDefenseStatusItem(status.physicalDefense);
			view.SetMagicalDefenseStatusItem(status.magicalDefense);
		}
	}

}
