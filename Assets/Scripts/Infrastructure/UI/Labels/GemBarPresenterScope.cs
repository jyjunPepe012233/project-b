using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.UI.Presenters.Labels.ResourceBar;
using ProjectB.UI.Views.Common;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Labels
{

	public class GemBarPresenterScope : UIPresenterScope<GemBarPresenter>
	{
		[SerializeField] private IntValueView intValueView;
		
		[Inject] private IPlayerDataService _playerDataService;
		
		protected override GemBarPresenter Compose()
		{
			return new GemBarPresenter(intValueView, _playerDataService);
		}
	}

}