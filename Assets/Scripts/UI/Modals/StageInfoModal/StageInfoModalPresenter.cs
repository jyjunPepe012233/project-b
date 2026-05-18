using ProjectB.Data.Static.Invasion;
using ProjectB.UI.Core;

namespace ProjectB.UI.Modals.StageInfoModal
{

	public class StageInfoModalPresenter : UIPresenter<StageInfoModalView>
	{
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.CloseButtonClicked += OnCloseButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.CloseButtonClicked -= OnCloseButtonClicked;
		}

		void OnCloseButtonClicked()
		{
			view.Hide();
		}

		public void InitializeStageInfo(IStageData stage)
		{
			view.InitializeStageInfo(stage.StageName);
		}
	}

}
