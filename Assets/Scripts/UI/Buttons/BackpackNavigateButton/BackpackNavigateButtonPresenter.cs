using ProjectB.Data.Types;
using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Buttons.BackpackNavigateButton
{

	public class BackpackNavigateButtonPresenter : UIPresenter<ButtonView>
	{
		[SerializeField] private ItemCategory _category;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.ButtonClicked += OnButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.ButtonClicked -= OnButtonClicked;
		}

		void OnButtonClicked()
		{
			BackpackNavigateButtonEvents.Clicked?.Invoke(_category);
		}
	}

}
