using ProjectB.Gameplay.Ports.Inbound.Player;
using ProjectB.UI.Core;
using ProjectB.UI.Presenters.Labels.ResourceBar;
using ProjectB.UI.Views.Label;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.Dependency.VContainer.PresenterScope
{

	public class GemBarPresenterScope : UIPresenterScope<GemBarPresenter>
	{
		[SerializeField] private IntValueLabelView _intValueLabelView;
		
		[Inject] private IPlayerDataService _playerDataService;
		
		protected override GemBarPresenter Compose()
		{
			return new GemBarPresenter(_intValueLabelView, _playerDataService);
		}
	}

}