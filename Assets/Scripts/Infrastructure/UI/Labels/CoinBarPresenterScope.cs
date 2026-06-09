using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.UI.Presenters.Labels.ResourceBar;
using ProjectB.UI.Views.Common;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Labels
{

	public class CoinBarPresenterScope : UIPresenterScope<CoinBarPresenter>
	{
		[SerializeField] private IntValueView intValueView;
		
		[Inject] private IPlayerDataService _playerDataService;
		
		protected override CoinBarPresenter Compose()
		{
			return new CoinBarPresenter(intValueView, _playerDataService);
		}
	}

}