using ProjectB.Data.Runtime.Summon;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Items;
using ProjectB.UI.Views.Lists;
using UnityEngine;

namespace ProjectB.UI.Presenters.Overlays
{

	public class SummonResultOverlayPresenter : BaseOverlayPresenter<SummonResultOverlayEvents>
	{
		private readonly PlayerSoldierCardListView _soldierListView;
		private readonly PlayerSoldierCardView _soldierCardPrefab;
		private readonly ButtonView _summonAgainButtonView;

		private readonly SummonResultEvents _summonResultEvents;
		private readonly ISummonService _summonService;

		private SummonResult _latestSummonResult;

		public SummonResultOverlayPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			SummonResultOverlayEvents overlayEvents,
			IOverlayStackService overlayStackService,
			PlayerSoldierCardListView soldierListView,
			PlayerSoldierCardView soldierCardPrefab, 
			ButtonView summonAgainButtonView,
			SummonResultEvents summonResultEvents,
			ISummonService summonService) : base(topElementView, closeButtonView, overlayEvents, overlayStackService)
		{
			_soldierListView = soldierListView;
			_soldierCardPrefab = soldierCardPrefab;
			_summonAgainButtonView = summonAgainButtonView;
			_summonResultEvents = summonResultEvents;
			_summonService = summonService;
		}

		public override void Initialize()
		{
			base.Initialize();
			_soldierListView.Initialize(_soldierCardPrefab, 10);
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_summonAgainButtonView.ButtonClicked += OnSummonAgainButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_summonAgainButtonView.ButtonClicked -= OnSummonAgainButtonClicked;
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_summonResultEvents.ShowSummonResult += OnShowSummonResult;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_summonResultEvents.ShowSummonResult -= OnShowSummonResult;
		}
		
		void OnSummonAgainButtonClicked()
		{
			_summonService.Summon(_latestSummonResult.type);
		}

		void OnShowSummonResult(SummonResult summonResult)
		{
			_latestSummonResult = summonResult;
			
			_soldierListView.ClearCards();
			foreach (var soldier in summonResult.summonedSoldiers)
			{
				var card = _soldierListView.CreateCard();
				card.Initialize(soldier.SoldierName,
					soldier.CardDisplaySetting.DisplayedSoldierPrefab,
					soldier.Role.IconPrefab64,
					soldier.Spirit.IconPrefab64);
			}
		}
	}

}