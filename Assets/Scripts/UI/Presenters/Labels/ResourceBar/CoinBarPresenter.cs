using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Inbound.Player;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Label;

namespace ProjectB.UI.Presenters.Labels.ResourceBar
{

	public class CoinBarPresenter : UIPresenter
	{
		private readonly IntValueLabelView _intValueLabelView;
		
		private readonly IPlayerDataService _playerDataService;
		
		// 생성자에서 할당
		private readonly IReadOnlyPlayerData _playerData;
		
		public CoinBarPresenter(IntValueLabelView intValueLabelView, IPlayerDataService playerDataService)
		{
			_intValueLabelView = intValueLabelView;
			_playerDataService = playerDataService;
			
			_playerData = _playerDataService.GetPlayerData();
		}

		public override void Initialize()
		{
			base.Initialize();
			_intValueLabelView.SetValue(_playerData.Coins);
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_playerData.CoinsChanged += OnCoinsChanged;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_playerData.CoinsChanged -= OnCoinsChanged;
		}
		
		void OnCoinsChanged()
		{
			_intValueLabelView.SetValue(_playerData.Coins);
		}
	}

}