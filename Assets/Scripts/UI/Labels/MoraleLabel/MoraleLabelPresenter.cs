using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Labels.MoraleLabel
{

	public class MoraleLabelPresenter : UIPresenter<MoraleLabelView>
	{
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;
		[SerializeField] private MoraleSettingInstaller _moraleSettingInstaller;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			_playerDataServicePortInstaller.Port.GetPlayerData().MoraleChanged += OnMoraleChanged;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			_playerDataServicePortInstaller.Port.GetPlayerData().MoraleChanged -= OnMoraleChanged;
		}

		void OnMoraleChanged()
		{
			UpdateMorale();
		}

		protected override void InitializeView()
		{
			base.InitializeView();
			UpdateMorale();
		}

		void UpdateMorale()
		{
			var morale = _playerDataServicePortInstaller.Port.GetPlayerData().Morale;
			var maxMorale = _moraleSettingInstaller.Port.MaxMorale;
			
			view.SetMoraleText(morale.ToString());
			view.SetMaxMoraleText(maxMorale.ToString());
		}
	}

}
