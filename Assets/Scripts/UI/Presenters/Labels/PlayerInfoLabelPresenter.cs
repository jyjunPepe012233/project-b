using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Player;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;

namespace ProjectB.UI.Presenters.Labels
{

	public class PlayerInfoLabelPresenter : UIPresenter
	{
		private readonly PlayerInfoLabelView _playerInfoLabelView;
		
		private readonly IPlayerInfoOverlayService _playerInfoOverlayService;
		private readonly IPlayerDataService _playerDataService;
		private readonly IPlayerLevelUpSetting _playerLevelUpSetting;

		private readonly IReadOnlyPlayerData _playerData;

		public PlayerInfoLabelPresenter(PlayerInfoLabelView playerInfoLabelView,
			IPlayerInfoOverlayService playerInfoOverlayService,
			IPlayerDataService playerDataService,
			IPlayerLevelUpSetting playerLevelUpSetting)
		{
			_playerInfoLabelView = playerInfoLabelView;
			_playerInfoOverlayService = playerInfoOverlayService;
			_playerDataService = playerDataService;
			_playerLevelUpSetting = playerLevelUpSetting;

			_playerData = _playerDataService.GetPlayerData();
		}

		public override void Initialize()
		{
			base.Initialize();
			InitializePlayerInfo();
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_playerInfoLabelView.ButtonClicked += OnButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_playerInfoLabelView.ButtonClicked -= OnButtonClicked;
		}

		void OnButtonClicked()
		{
			_playerInfoOverlayService.Open();
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_playerData.LevelChanged += OnPlayerLevelChanged;
			_playerData.ExperienceChanged += OnPlayerExperienceChanged;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_playerData.LevelChanged -= OnPlayerLevelChanged;
			_playerData.ExperienceChanged -= OnPlayerExperienceChanged;
		}

		void OnPlayerLevelChanged()
		{
			_playerInfoLabelView.SetLevel(_playerData.Level);
			InitializeExperience();
		}

		void OnPlayerExperienceChanged()
		{
			InitializeExperience();
		}

		void InitializePlayerInfo()
		{
			_playerInfoLabelView.Initialize(_playerData.PlayerName,
				_playerData.Level,
				_playerData.Experience,
				_playerLevelUpSetting.GetLevelUpExpOfLevel(_playerData.Level));
		}

		void InitializeExperience()
		{
			_playerInfoLabelView.SetExperienceProgress(_playerData.Experience,
				_playerLevelUpSetting.GetLevelUpExpOfLevel(_playerData.Level));
		}
	}

}
