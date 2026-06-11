using ProjectB.Data.Static.Invasion;
using ProjectB.Gameplay.Events;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;

namespace ProjectB.UI.Presenters.Buttons
{

	public class StageInfoButtonPresenter : UIPresenter
	{
		private readonly ButtonView _buttonView;
		
		private readonly IStageData _stageData;
		private readonly StageInfoEvents _stageInfoEvents;

		public StageInfoButtonPresenter(ButtonView buttonView, IStageData stageData, StageInfoEvents stageInfoEvents)
		{
			_buttonView = buttonView;
			_stageData = stageData;
			_stageInfoEvents = stageInfoEvents;
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_buttonView.ButtonClicked += OnButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_buttonView.ButtonClicked -= OnButtonClicked;
		}

		void OnButtonClicked()
		{
			_stageInfoEvents.StageInfoSelected?.Invoke(_stageData);
		}
	}

}