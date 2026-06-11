using ProjectB.Data.Static.Player;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.UI.Presenters.Overlays;
using ProjectB.UI.Views.Common;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Overlays
{

	public class PlayerInfoOverlayPresenterScope : BaseOverlayPresenterScope<PlayerInfoOverlayPresenter, PlayerInfoOverlayEvents>
	{
		[SerializeField] private TextView _playerNameView;
		[SerializeField] private IntValueView _levelView;
		[SerializeField] private ProgressBarView _experienceProgressBarView;
		[SerializeField] private IntValueView _combatPowerView;

		[Inject] private SoldierInfoEvents _soldierInfoEvents;
		[Inject] private IPlayerDataService _playerDataService;
		[Inject] private IPlayerLevelUpSetting _playerLevelUpSetting;

		protected override PlayerInfoOverlayPresenter Compose()
		{
			return new PlayerInfoOverlayPresenter(_topElementView,
				_closeButtonView,
				_overlayEvents,
				_overlayStackService,
				_playerNameView,
				_levelView,
				_experienceProgressBarView,
				_combatPowerView,
				_soldierInfoEvents,
				_playerDataService,
				_playerLevelUpSetting);
		}
	}

}
