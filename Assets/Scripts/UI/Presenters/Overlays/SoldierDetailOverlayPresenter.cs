using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Soldier;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Pages.SoldierDetail;

namespace ProjectB.UI.Presenters.Overlays
{

	public class SoldierDetailOverlayPresenter : BaseOverlayPresenter<SoldierDetailOverlayEvents>
	{
		private readonly ButtonView _infoPageButtonView;
		private readonly ButtonView _levelUpPageButtonView;
		
		private readonly SoldierDetailInfoPageView _infoPageView;
		private readonly SoldierDetailLevelUpPageView _levelUpPageView;

		private readonly SoldierDetailEvents _soldierDetailEvents;
		private readonly ISoldierLevelUpService _soldierLevelUpService;

		
		private IReadOnlyPlayerSoldier _currentSoldier;
		private UIView _currentPageView;

		public SoldierDetailOverlayPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			SoldierDetailOverlayEvents overlayEvents,
			IOverlayStackService overlayStackService,
			ButtonView infoPageButtonView,
			ButtonView levelUpPageButtonView,
			SoldierDetailInfoPageView infoPageView,
			SoldierDetailLevelUpPageView levelUpPageView, 
			SoldierDetailEvents soldierDetailEvents,
			ISoldierLevelUpService soldierLevelUpService) : base(topElementView, closeButtonView, overlayEvents, overlayStackService)
		{
			_infoPageButtonView = infoPageButtonView;
			_levelUpPageButtonView = levelUpPageButtonView;
			_infoPageView = infoPageView;
			_levelUpPageView = levelUpPageView;
			_soldierDetailEvents = soldierDetailEvents;
			_soldierLevelUpService = soldierLevelUpService;
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_infoPageButtonView.ButtonClicked += OnInfoPageButtonClicked;
			_levelUpPageButtonView.ButtonClicked += OnLevelUpPageButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_infoPageButtonView.ButtonClicked -= OnInfoPageButtonClicked;
			_levelUpPageButtonView.ButtonClicked -= OnLevelUpPageButtonClicked;
		}
		
		void OnInfoPageButtonClicked()
		{
			if (_currentPageView == _infoPageView)
			{
				return;
			}

			_currentPageView.Hide();
			_currentPageView = _infoPageView;
			InitializeCurrentPage();
			ShowCurrentPage();
		}
		
		void OnLevelUpPageButtonClicked()
		{
			if (_currentPageView == _levelUpPageView)
			{
				return;
			}

			_currentPageView.Hide();
			_currentPageView = _levelUpPageView;
			InitializeCurrentPage();
			ShowCurrentPage();
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_soldierDetailEvents.SelectSoldier += OnSelectSoldier;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_soldierDetailEvents.SelectSoldier -= OnSelectSoldier;
		}

		void OnSelectSoldier(IReadOnlyPlayerSoldier soldier)
		{
			_currentSoldier = soldier;
			InitializeCurrentPage();
		}


		// 화면이 처음 열리면 정보 페이지를 염
		protected override void OnOpenScreen()
		{
			base.OnOpenScreen();

			_currentPageView = _infoPageView;
			InitializeCurrentPage();
			ShowCurrentPage();
		}

		protected override void OnShowScreen()
		{
			base.OnShowScreen();

			if (_currentPageView == null)
			{
				_currentPageView = _infoPageView;
			}

			InitializeCurrentPage();
			ShowCurrentPage();
		}

		void InitializeCurrentPage()
		{
			switch (_currentPageView)
			{
				case SoldierDetailInfoPageView infoPageView:
					InitializeInfoPage();
					break;
				case SoldierDetailLevelUpPageView levelUpPageView:
					InitializeLevelUpPage();
					_levelUpPageView.Show(includeDefaultDisable: true);
					break;
			}
		}

		void ShowCurrentPage()
		{
			if (_currentPageView != null)
			{
				// 페이지 View들은 defaultDisable로 되어 있기 때문에
				// includeDefaultDisable: true로 설정함
				_currentPageView.Show(true);
			}
		}

		void InitializeInfoPage()
		{
			_infoPageView.Initialize(null,
				_currentSoldier.Rank,
				_currentSoldier.Level,
				_currentSoldier.CombatPower,
				_currentSoldier.Status);
		}

		void InitializeLevelUpPage()
		{
			_levelUpPageView.Initialize(_currentSoldier.Level, _currentSoldier.Level + 1,
				_currentSoldier.Exp, _currentSoldier.SoldierData.LevelUpSetting.GetLevelUpExpOfLevel(_currentSoldier.Level),
				_currentSoldier.CombatPower, _soldierLevelUpService.GetNextLevelCombatPower(_currentSoldier.SoldierData),
				_currentSoldier.Status, _soldierLevelUpService.GetNextLevelStatus(_currentSoldier.SoldierData));
		}
	}

}