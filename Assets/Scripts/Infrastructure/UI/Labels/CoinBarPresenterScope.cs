using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.UI.Presenters.Labels.ResourceBar;
using ProjectB.UI.Views.Label;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.Dependency.VContainer.PresenterScope
{

	public class CoinBarPresenterScope : UIPresenterScope<CoinBarPresenter>
	{
		[SerializeField] private IntValueLabelView _intValueLabelView;
		
		[Inject] private IPlayerDataService _playerDataService;
		
		protected override CoinBarPresenter Compose()
		{
			return new CoinBarPresenter(_intValueLabelView, _playerDataService);
		}
	}

}