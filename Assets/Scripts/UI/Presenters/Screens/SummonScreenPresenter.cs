using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;

namespace ProjectB.UI.Presenters.Screens
{

	public class SummonScreenPresenter : BaseScreenPresenter<ISummonScreenService>
	{
		private readonly ButtonView _summon1xButtonView;
		private readonly ButtonView _summon10xButtonView;
		
		private readonly ISummonService _summonService;

		public SummonScreenPresenter(TopElementView topElementView,
			ButtonView closeButton,
			ISummonScreenService summonScreenService,
			ButtonView summon1XButtonView,
			ButtonView summon10XButtonView,
			ISummonService summonService) : base(topElementView, closeButton, summonScreenService)
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