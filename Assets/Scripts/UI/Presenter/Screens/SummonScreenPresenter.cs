using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.UI.View.Buttons;
using ProjectB.UI.View.Common;

namespace ProjectB.UI.Presenter.Screens
{

	public class SummonScreenPresenter : BaseScreenPresenter<ISummonScreenService>
	{
		private readonly ButtonView _summon1xButtonView;
		private readonly ButtonView _summon10xButtonView;
		
		private readonly ISummonServicePort _summonServicePort;

		public SummonScreenPresenter(TopElementView topElementView,
			ButtonView closeButton,
			ISummonScreenService summonScreenService,
			ButtonView summon1XButtonView,
			ButtonView summon10XButtonView,
			ISummonServicePort summonServicePort) : base(topElementView, closeButton, summonScreenService)
		{
			_summon1xButtonView = summon1XButtonView;
			_summon10xButtonView = summon10XButtonView;
			_summonServicePort = summonServicePort;
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
			_summonServicePort.Summon(SummonType.Summon1x);
		}
		
		void OnSummon10XButtonClicked()
		{
			_summonServicePort.Summon(SummonType.Summon10x);
		}
	}

}