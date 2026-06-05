using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Inbound.Player;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Label;

namespace ProjectB.UI.Presenters.Labels.ResourceBar
{

	public class GemBarPresenter : UIPresenter
	{
		private readonly IntValueLabelView _intValueLabelView;
		
		private readonly IPlayerDataService _playerDataService; // 생성자 밖에서 사용하지는 않지만 의존성 명시를 위해 참조를 유지하고 있겠음
		
		// 생성자에서 할당
		private readonly IReadOnlyPlayerData _playerData;
		
		public GemBarPresenter(IntValueLabelView intValueLabelView, IPlayerDataService playerDataService)
		{
			_intValueLabelView = intValueLabelView;
			_playerDataService = playerDataService;
			
			_playerData = _playerDataService.GetPlayerData();
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_playerData.GemsChanged += OnGemsChanged;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_playerData.GemsChanged -= OnGemsChanged;
		}
		
		void OnGemsChanged()
		{
			_intValueLabelView.SetValue(_playerData.Gems);
		}
	}

}