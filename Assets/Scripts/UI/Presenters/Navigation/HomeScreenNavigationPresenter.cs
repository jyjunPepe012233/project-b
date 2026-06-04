using System;
using ProjectB.Gameplay.Ports.Inbound.Overlay;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Buttons;

namespace ProjectB.UI.Presenters.Navigation
{

	// Home 화면에서, 다른 화면으로 이동하는 버튼들을 관리하는 Presenter
	public class HomeScreenNavigationPresenter : UIPresenter
	{
		private readonly ButtonView _summonButtonView; // 모집
		private readonly ButtonView _shopButtonView; // 상점
		private readonly ButtonView _soldierListButtonView; // 병사 목록
		private readonly ButtonView _worldMapButtonView; // 월드맵(침략)
		
		private readonly ISummonOverlayService _summonOverlayService;
		private readonly IShopOverlayService _shopOverlayService;
		private readonly ISoldierListOverlayService _soldierListOverlayService;
		private readonly IWorldMapOverlayService _worldMapOverlayService;

		public HomeScreenNavigationPresenter(ButtonView summonButtonView,
			ButtonView shopButtonView,
			ButtonView soldierListButtonView,
			ButtonView worldMapButtonView,
			ISummonOverlayService summonOverlayService,
			IShopOverlayService shopOverlayService,
			ISoldierListOverlayService soldierListOverlayService,
			IWorldMapOverlayService worldMapOverlayService)
		{
			_summonButtonView = summonButtonView;
			_shopButtonView = shopButtonView;
			_soldierListButtonView = soldierListButtonView;
			_worldMapButtonView = worldMapButtonView;
			_summonOverlayService = summonOverlayService;
			_shopOverlayService = shopOverlayService;
			_soldierListOverlayService = soldierListOverlayService;
			_worldMapOverlayService = worldMapOverlayService;
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
			_summonOverlayService.Open();
		}
		
		void OnSoldierListButtonClicked()
		{
			_soldierListOverlayService.Open();
		}
		
		void OnShopButtonClicked()
		{
			_shopOverlayService.Open();
		}
		
		void OnWorldMapButtonClicked()
		{
			_worldMapOverlayService.Open();
		}
	}

}
