using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using ProjectB.Gameplay.Events;
using ProjectB.UI.Presenters.Buttons;
using ProjectB.UI.Views.Buttons;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Buttons
{

	public class StageInfoButtonPresenterScope : UIPresenterScope<StageInfoButtonPresenter>
	{
		[SerializeField] private ButtonView _buttonView;
		[SerializeField] private InterfaceRef<IStageData> _stageData;
		
		[Inject] private StageInfoEvents _stageInfoEvents;
		
		protected override StageInfoButtonPresenter Compose()
		{
			return new StageInfoButtonPresenter(_buttonView,
				_stageData.Value,
				_stageInfoEvents);
		}
	}

}