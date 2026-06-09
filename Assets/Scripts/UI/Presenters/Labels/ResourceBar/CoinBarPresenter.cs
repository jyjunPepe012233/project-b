using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Inbound.Ports.Player;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Common;

namespace ProjectB.UI.Presenters.Labels.ResourceBar
{

	public class CoinBarPresenter : UIPresenter
	{
		private readonly IntValueView _intValueView;
		
		private readonly IPlayerDataService _playerDataService;
		
		// 생성자에서 할당
		private readonly IReadOnlyPlayerData _playerData;
		
		public CoinBarPresenter(IntValueView intValueView, IPlayerDataService playerDataService)
		{
			_intValueView = intValueView;
			_playerDataService = playerDataService;
			
			_playerData = _playerDataService.GetPlayerData();
		}

		public override void Initialize()
		{
			base.Initialize();
			_intValueView.SetValue(_playerData.Coins);
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
			_intValueView.SetValue(_playerData.Coins);
		}
	}

}