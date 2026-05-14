using System;
using ProjectB.UI.Core;
using ProjectB.UI.Parts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Popups.MoraleRechargePopup
{

	[Serializable]
	public class MoraleRechargePopupView : UIView
	{
		[SerializeField] private Button _closeButton;
		
		[Header("Recharge Count")]
		[SerializeField] private TextMeshProUGUI _remainingRechargeCountText;
		[SerializeField] private TextMeshProUGUI _maxRechargeCountText;
		
		[Header("Morale")]
		[SerializeField] private TextMeshProUGUI _currentMoraleText;
		[SerializeField] private TextMeshProUGUI _exptectedMoraleText;
		
		[Header("Cost")]
		[SerializeField] private TextMeshProUGUI _currentMoraleCostText;
		[SerializeField] private TextMeshProUGUI _rechargeCostText;
		
		[Header("Stepper")]
		[SerializeField] private NumericStepper _rechargeCountStepper;
		
		[Header("Recharge Button")]
		[SerializeField] private Button _rechargeButton;
		
		public int RechargeCount => _rechargeCountStepper.Value;

		public event Action CloseButtonClicked;
		public event Action RechargeButtonClicked;
		public event Action RechargeCountStepperValueChanged;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_closeButton.onClick.AddListener(OnCloseButtonClicked);
			_rechargeButton.onClick.AddListener(OnRechargeButtonClicked);

			_rechargeCountStepper.ValueChanged += OnValueChanged;
		}

		public override void Dispose()
		{
			base.Dispose();
			_closeButton.onClick.RemoveListener(OnCloseButtonClicked);
			_rechargeButton.onClick.RemoveListener(OnRechargeButtonClicked);
			
			_rechargeCountStepper.ValueChanged -= OnValueChanged;
		}

		void OnCloseButtonClicked()
		{
			CloseButtonClicked?.Invoke();
		}
		
		void OnRechargeButtonClicked()
		{
			RechargeButtonClicked?.Invoke();
		}

		void OnValueChanged()
		{
			RechargeCountStepperValueChanged?.Invoke();
		}
		
		public void SetRemainingRechargeCount(int count)
		{
			_remainingRechargeCountText.text = count.ToString();
		}
		
		public void SetMaxRechargeCount(int count)
		{
			_maxRechargeCountText.text = count.ToString();
		}
		
		public void SetCurrentMorale(int morale)
		{
			_currentMoraleText.text = morale.ToString();
		}
		
		public void SetExpectedMorale(int morale)
		{
			_exptectedMoraleText.text = morale.ToString();
		}
		
		public void SetCurrentMoraleCost(int cost)
		{
			_currentMoraleCostText.text = cost.ToString();
		}
		
		public void SetRechargeCost(int cost)
		{
			_rechargeCostText.text = cost.ToString();
		}
		
		public void SetRechargeCountStepperMinValue(int minValue)
		{
			_rechargeCountStepper.SetMinValue(minValue);
		}

		public void SetRechargeCountStepperMaxValue(int maxValue)
		{
			_rechargeCountStepper.SetMaxValue(maxValue);
		}
		
		public void SetRechargeCountStepperIncrementButtonInteractable(bool interactable) // 이름 너무 안 기나?
		{
			_rechargeCountStepper.SetIncrementButtonInteractable(interactable);
		}
		
		public void SetRechargeCountStepperDecrementButtonInteractable(bool interactable)
		{
			_rechargeCountStepper.SetDecrementButtonInteractable(interactable);
		}
		
		public void SetRechargeButtonInteractable(bool interactable)
		{
			_rechargeButton.interactable = interactable;
		}
	}

}
