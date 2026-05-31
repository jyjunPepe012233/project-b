using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Inbound.Screen;
using ProjectB.UI.Core;
using ProjectB.UI.View.Buttons;
using ProjectB.UI.View.Common;

namespace ProjectB.UI.Presenters.Screens
{

	public class SummonScreenPresenter : UIPresenter
	{
		private readonly TopElementView _topElementView;
		private readonly ButtonView _backButtonView;
		private readonly ButtonView _summon1xButtonView;
		private readonly ButtonView _summon10xButtonView;
		
		private readonly ISummonServicePort _summonServicePort;
		private readonly ISummonScreenService _summonScreenService;

		public SummonScreenPresenter(TopElementView topElementView,
			ButtonView backButtonView,
			ButtonView summon1XButtonView,
			ButtonView summon10XButtonView,
			ISummonServicePort summonServicePort,
			ISummonScreenService summonScreenService)
		{
			_topElementView = topElementView;
			_backButtonView = backButtonView;
			_summon1xButtonView = summon1XButtonView;
			_summon10xButtonView = summon10XButtonView;
			_summonServicePort = summonServicePort;
			_summonScreenService = summonScreenService;
		}

		protected override void SetupViewCallbacks()
		{
			base.SetupViewCallbacks();
			_backButtonView.ButtonClicked += OnBackButtonClicked;
			_summon1xButtonView.ButtonClicked += OnSummon1XButtonClicked;
			_summon10xButtonView.ButtonClicked += OnSummon10XButtonClicked;
		}

		protected override void DisposeViewCallbacks()
		{
			base.DisposeViewCallbacks();
			_backButtonView.ButtonClicked -= OnBackButtonClicked;
			_summon1xButtonView.ButtonClicked -= OnSummon1XButtonClicked;
			_summon10xButtonView.ButtonClicked -= OnSummon10XButtonClicked;
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_summonScreenService.Events.Open += OnScreenOpened;
			_summonScreenService.Events.Close += OnScreenClosed;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_summonScreenService.Events.Open -= OnScreenOpened;
			_summonScreenService.Events.Close -= OnScreenClosed;
		}

		void OnBackButtonClicked()
		{
			_summonScreenService.Close();
		}
		
		void OnSummon1XButtonClicked()
		{
			_summonServicePort.Summon(SummonType.Summon1x);
		}
		
		void OnSummon10XButtonClicked()
		{
			_summonServicePort.Summon(SummonType.Summon10x);
		}
		
		void OnScreenOpened()
		{
			_topElementView.Show();
		}

		void OnScreenClosed()
		{
			_topElementView.Hide();
		}
	}

}