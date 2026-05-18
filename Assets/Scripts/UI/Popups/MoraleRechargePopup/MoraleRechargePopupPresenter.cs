using ProjectB.Dependency.Installers;
using ProjectB.UI.Buttons.MoraleRechargeMenuButton;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Popups.MoraleRechargePopup
{

	public class MoraleRechargePopupPresenter : UIPresenter<MoraleRechargePopupView>
	{
		[SerializeField] private MoraleSettingInstaller _moraleSettingInstaller;
		[SerializeField] private RechargeMoraleServicePortInstaller _rechargeMoraleServicePortInstaller;
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			MoraleRechargeMenuButtonEvents.Clicked += OnMoraleRechargeMenuButtonClicked;

			view.CloseButtonClicked += OnCloseButtonClicked;
			view.RechargeButtonClicked += OnRechargeButtonClicked;
			view.RechargeCountStepperValueChanged += OnRechargeCountChanged;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			MoraleRechargeMenuButtonEvents.Clicked -= OnMoraleRechargeMenuButtonClicked;

			view.CloseButtonClicked -= OnCloseButtonClicked;
			view.RechargeButtonClicked -= OnRechargeButtonClicked;
			view.RechargeCountStepperValueChanged -= OnRechargeCountChanged;
		}

		void OnMoraleRechargeMenuButtonClicked()
		{
			UpdateView();
			Show();
		}

		void OnCloseButtonClicked()
		{
			Hide();
		}
		
		void OnRechargeButtonClicked()
		{
			_rechargeMoraleServicePortInstaller.Port.Recharge(view.RechargeCount);
			Hide();
		}

		void OnRechargeCountChanged()
		{
			UpdateView();
		}

		protected override void InitializeView()
		{
			base.InitializeView();
			UpdateView();
		}

		void UpdateView()
		{
			var rechargeMoraleService = _rechargeMoraleServicePortInstaller.Port;
			var moraleSetting = _moraleSettingInstaller.Port;
			var playerData = _playerDataServicePortInstaller.Port.GetPlayerData();

			view.SetRemainingRechargeCount(rechargeMoraleService.GetRemainingRechargeCount());
			view.SetMaxRechargeCount(moraleSetting.MaxDailyRechargeCount);
			
			view.SetCurrentMorale(playerData.Morale);
			view.SetExpectedMorale(rechargeMoraleService.GetExpectedMoraleAfterRecharge(view.RechargeCount));
			
			view.SetCurrentMoraleCost(playerData.Gems); // 사기 충전 비용은 보석임
			view.SetRechargeCost(rechargeMoraleService.GetRechargeCost(view.RechargeCount));
			
			// Stepper 조작
			int remainingRechargeCount = rechargeMoraleService.GetRemainingRechargeCount();
			view.SetRechargeCountStepperMinValue(1); // 최소 1회 충전부터 가능
			view.SetRechargeCountStepperMaxValue(remainingRechargeCount); // Stepper는 입력된 값이 Max Value를 넘으면 자동으로 되돌리능 기능이 있음. 해당 기능을 활용함
			view.SetRechargeCountStepperIncrementButtonInteractable(view.RechargeCount < remainingRechargeCount); // stepper 값 증가 버튼 조작
			view.SetRechargeCountStepperDecrementButtonInteractable(view.RechargeCount > 1); // stepper의 값 감소 버튼 조작 
		}
	}

}
