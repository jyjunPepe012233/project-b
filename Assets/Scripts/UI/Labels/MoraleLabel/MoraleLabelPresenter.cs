using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using ProjectB.UI.Labels.Common;
using UnityEngine;

namespace ProjectB.UI.Labels.MoraleLabel
{

	public class MoraleLabelPresenter : UIPresenter<JustTextLabelView>
	{
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;

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
			view.SetText(_playerDataServicePortInstaller.Port.GetPlayerData().Morale.ToString());
		}
	}

}
