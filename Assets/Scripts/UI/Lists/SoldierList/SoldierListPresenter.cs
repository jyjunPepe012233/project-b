using System.Collections.Generic;
using ProjectB.Data.Static.Soldier;
using ProjectB.UI.Core;

namespace ProjectB.UI.Lists.SoldierList
{

	public class SoldierListPresenter : UIPresenter<SoldierListView>
	{
		public void UpdateSoldiers(IEnumerable<ISoldierData> soldiers)
		{
			view.UpdateSoldiers(soldiers);
		}
	}

}