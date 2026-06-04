using ProjectB.Data.Types;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Inbound.Overlay;
using ProjectB.UI.Presenters.Screens;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;

namespace ProjectB.UI.Presenters.Overlays
{

	public class SummonOverlayPresenter : BaseOverlayPresenter<ISummonOverlayService, SummonOverlayEvents>
	{
		private readonly ButtonView _summon1xButtonView;
		private readonly ButtonView _summon10xButtonView;
		
		private readonly ISummonService _summonService;

		public SummonOverlayPresenter(TopElementView topElementView,
			ButtonView closeButton,
			ISummonOverlayService overlayService,
			SummonOverlayEvents overlayEvents,
			ButtonView summon1XButtonView,
			ButtonView summon10XButtonView,
			ISummonService summonService) : base(topElementView, closeButton, overlayService, overlayEvents)
		{
			_summon1xButtonView = summon1XButtonView;
			_summon10xButtonView = summon10XButtonView;
			_summonService = summonService;
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_summon1xButtonView.ButtonClicked += OnSummon1XButtonClicked;
			_summon10xButtonView.ButtonClicked += OnSummon10XButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_summon1xButtonView.ButtonClicked -= OnSummon1XButtonClicked;
			_summon10xButtonView.ButtonClicked -= OnSummon10XButtonClicked;
		}
		
		void OnSummon1XButtonClicked()
		{
			_summonService.Summon(SummonType.Summon1x);
		}
		
		void OnSummon10XButtonClicked()
		{
			_summonService.Summon(SummonType.Summon10x);
		}
	}

}
