using ProjectB.Data.Static.Player;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.UI.Presenters.Labels;
using ProjectB.UI.Views.Buttons;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Labels
{

	public class PlayerInfoLabelPresenterScope : UIPresenterScope<PlayerInfoLabelPresenter>
	{
		[SerializeField] private PlayerInfoLabelView _playerInfoLabelView;
		
		[Inject] private IPlayerInfoOverlayService _playerInfoOverlayService;
		[Inject] private IPlayerDataService _playerDataService;
		[Inject] private IPlayerLevelUpSetting _playerLevelUpSetting;

		protected override PlayerInfoLabelPresenter Compose()
		{
			return new PlayerInfoLabelPresenter(_playerInfoLabelView,
				_playerInfoOverlayService,
				_playerDataService,
				_playerLevelUpSetting);
		}
	}

}
