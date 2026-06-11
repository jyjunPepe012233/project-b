using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Player;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;

namespace ProjectB.UI.Presenters.Overlays
{

	public class PlayerInfoOverlayPresenter : BaseOverlayPresenter<PlayerInfoOverlayEvents>
	{
		private readonly TextView _playerNameView;
		private readonly IntValueView _levelView;
		private readonly ProgressBarView _experienceProgressBarView;
		private readonly IntValueView _combatPowerView;

		private readonly SoldierInfoEvents _soldierInfoEvents;
		private readonly IPlayerDataService _playerDataService;
		private readonly IPlayerLevelUpSetting _playerLevelUpSetting;

		private readonly IReadOnlyPlayerData _playerData;

		public PlayerInfoOverlayPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			PlayerInfoOverlayEvents overlayEvents,
			IOverlayStackService overlayStackService,
			TextView playerNameView,
			IntValueView levelView,
			ProgressBarView experienceProgressBarView,
			IntValueView combatPowerView,
			SoldierInfoEvents soldierInfoEvents,
			IPlayerDataService playerDataService,
			IPlayerLevelUpSetting playerLevelUpSetting) : base(topElementView, closeButtonView, overlayEvents, overlayStackService)
		{
			_playerNameView = playerNameView;
			_levelView = levelView;
			_experienceProgressBarView = experienceProgressBarView;
			_combatPowerView = combatPowerView;
			_soldierInfoEvents = soldierInfoEvents;
			_playerDataService = playerDataService;
			_playerLevelUpSetting = playerLevelUpSetting;

			_playerData = _playerDataService.GetPlayerData();
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_playerData.LevelChanged += OnPlayerLevelChanged;
			_playerData.ExperienceChanged += OnPlayerExperienceChanged;
			_soldierInfoEvents.StatusUpdated += OnSoldierStatusUpdated;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_playerData.LevelChanged -= OnPlayerLevelChanged;
			_playerData.ExperienceChanged -= OnPlayerExperienceChanged;
			_soldierInfoEvents.StatusUpdated -= OnSoldierStatusUpdated;
		}

		void OnPlayerLevelChanged()
		{
			InitializeLevel();
			InitializeExperience();
		}

		void OnPlayerExperienceChanged()
		{
			InitializeExperience();
		}

		void OnSoldierStatusUpdated(IPlayerSoldier playerSoldier)
		{
			InitializeCombatPower();
		}

		protected override void OnOpenScreen()
		{
			base.OnOpenScreen();
			InitializePlayerInfo();
		}

		protected override void OnShowScreen()
		{
			base.OnShowScreen();
			InitializePlayerInfo();
		}

		protected virtual void InitializePlayerInfo()
		{
			_playerNameView.SetText(_playerData.PlayerName);
			InitializeLevel();
			InitializeExperience();
			InitializeCombatPower();
		}

		void InitializeLevel()
		{
			_levelView.SetValue(_playerData.Level);
		}

		void InitializeExperience()
		{
			_experienceProgressBarView.SetProgress(_playerData.Experience,
				_playerLevelUpSetting.GetLevelUpExpOfLevel(_playerData.Level));
		}

		void InitializeCombatPower()
		{
			_combatPowerView.SetValue(_playerDataService.GetTotalCombatPower());
		}
	}

}
