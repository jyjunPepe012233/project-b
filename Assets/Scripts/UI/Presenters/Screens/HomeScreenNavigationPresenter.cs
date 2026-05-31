using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.UI.Core;
using ProjectB.UI.View.Buttons;

namespace ProjectB.UI.Presenters.Screens
{

	// Home 화면에서, 다른 화면으로 이동하는 버튼들을 관리하는 Presenter
	public class HomeScreenNavigationPresenter : UIPresenter
	{
		private readonly ButtonView _summonButtonView; // 모집
		private readonly ButtonView _shopButtonView; // 상점
		private readonly ButtonView _soldierListButtonView; // 병사 목록
		private readonly ButtonView _worldMapButtonView; // 월드맵(침략)
		
		private readonly ISummonScreenService _summonScreenService;
		private readonly IShopScreenService _shopScreenService;
		private readonly ISoldierListScreenService _soldierListScreenService;
		private readonly IWorldMapScreenService _worldMapScreenService;

		public HomeScreenNavigationPresenter(ButtonView summonButtonView,
			ButtonView shopButtonView,
			ButtonView soldierListButtonView,
			ButtonView worldMapButtonView,
			ISummonScreenService summonScreenService,
			IShopScreenService shopScreenService,
			ISoldierListScreenService soldierListScreenService,
			IWorldMapScreenService worldMapScreenService)
		{
			_summonButtonView = summonButtonView;
			_shopButtonView = shopButtonView;
			_soldierListButtonView = soldierListButtonView;
			_worldMapButtonView = worldMapButtonView;
			_summonScreenService = summonScreenService;
			_shopScreenService = shopScreenService;
			_soldierListScreenService = soldierListScreenService;
			_worldMapScreenService = worldMapScreenService;
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_summonButtonView.ButtonClicked += OnSummonButtonClicked;
			_shopButtonView.ButtonClicked += OnShopButtonClicked;
			_soldierListButtonView.ButtonClicked += OnSoldierListButtonClicked;
			_worldMapButtonView.ButtonClicked += OnWorldMapButtonClicked;
		}
		
		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_summonButtonView.ButtonClicked -= OnSummonButtonClicked;
			_shopButtonView.ButtonClicked -= OnShopButtonClicked;
			_soldierListButtonView.ButtonClicked -= OnSoldierListButtonClicked;
			_worldMapButtonView.ButtonClicked -= OnWorldMapButtonClicked;
		}
		
		void OnSummonButtonClicked()
		{
			_summonScreenService.Open();
		}
		
		void OnSoldierListButtonClicked()
		{
			_soldierListScreenService.Open();
		}
		
		void OnShopButtonClicked()
		{
			_shopScreenService.Open();
		}
		
		void OnWorldMapButtonClicked()
		{
			_worldMapScreenService.Open();
		}
	}

}