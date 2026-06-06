using ProjectB.Data.Types;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;

namespace ProjectB.UI.Presenters.Overlays
{

	public class SummonOverlayPresenter : BaseOverlayPresenter<SummonOverlayEvents>
	{
		private readonly ButtonView _summon1xButtonView;
		private readonly ButtonView _summon10xButtonView;
		
		private readonly ISummonService _summonService;


		public SummonOverlayPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			SummonOverlayEvents overlayEvents,
			IOverlayStackService overlayStackService,
			ButtonView summon1XButtonView,
			ButtonView summon10XButtonView,
			ISummonService summonService) : base(topElementView, closeButtonView, overlayEvents, overlayStackService)
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
