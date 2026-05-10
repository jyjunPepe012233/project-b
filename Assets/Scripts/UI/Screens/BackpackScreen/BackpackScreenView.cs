using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Types;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.BackpackScreen
{

	[Serializable]
	public class BackpackScreenView : UIView
	{
		[Header("Pages")]
		[SerializeField] private BackpackPage _consumablePage;
		[SerializeField] private BackpackPage _equipmentPage;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_consumablePage.RegisterUICallbacks();
			_equipmentPage.RegisterUICallbacks();
		}

		public override void Dispose()
		{
			base.Dispose();
			_consumablePage.Dispose();
			_equipmentPage.Dispose();
		}

		public void SetVisibleConsumablePage(bool active)
		{
			SetVisiblePage(_consumablePage, active);
		}

		public void SetVisibleEquipmentPage(bool active)
		{
			SetVisiblePage(_equipmentPage, active);
		}

		void SetVisiblePage(BackpackPage page, bool active)
		{
			if (active)
				page.Show();
			else
				page.Hide();
		}

		public void UpdateConsumablePage(IEnumerable<IPlayerItem> playerItems)
		{
			_consumablePage.UpdateItemSlots(playerItems);
		}
		
		public void UpdateEquipmentPage(IEnumerable<IPlayerItem> playerItems)
		{
			_equipmentPage.UpdateItemSlots(playerItems);
		}
	}

}