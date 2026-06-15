using ProjectB.Gameplay.Events;
using ProjectB.UI.Presenters.PopUps;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Media;
using UnityEngine;
using UnityEngine.Playables;
using VContainer;

namespace ProjectB.Infrastructure.UI.PopUps
{

	public class AlertPopUpPresenterScope : UIPresenterScope<AlertPopUpPresenter>
	{
		[SerializeField] private TopElementView _topElementView;
		[SerializeField] private TextView _alertMessageView;
		[SerializeField] private PlayableView _playableView;
		[SerializeField] private PlayableAsset _playableAsset;
		
		[Inject] private AlertEvents _alertEvents;
		
		protected override AlertPopUpPresenter Compose()
		{
			return new AlertPopUpPresenter(_topElementView,
				_alertMessageView,
				_playableView,
				_playableAsset,
				_alertEvents);
		}
	}

}
