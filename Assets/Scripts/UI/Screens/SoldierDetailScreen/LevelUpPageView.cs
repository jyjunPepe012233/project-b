using System;
using ProjectB.Data.Types;
using ProjectB.UI.Lists.SoldierStatusUpgradeList;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Screens.SoldierDetailScreen
{

	[Serializable]
	public class LevelUpPageView : SoldierDetailPageView
	{
		[Header("Status")]
		[SerializeField] private SoldierStatusUpgradeListComponent _statusUpgradeList;
		
		[Header("Combat Power")]
		[SerializeField] private TextMeshProUGUI _currentCombatPowerText;
		[SerializeField] private TextMeshProUGUI _nextLevelCombatPowerText;
		
		[Header("Level")]
		[SerializeField] private TextMeshProUGUI _currentLevelText;
		[SerializeField] private TextMeshProUGUI _nextLevelText;
		
		[Header("Experience")]
		[SerializeField] private Slider _experienceSlider;
		[SerializeField] private TextMeshProUGUI _currentExperienceText;
		[SerializeField] private TextMeshProUGUI _targetExperienceText;
		
		[Header("Consume Food Button")]
		[SerializeField] private Button _consumeFoodButton;
		[SerializeField] private TextMeshProUGUI _consumeFoodAmountText;

		public event Action ConsumeFoodButtonClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_consumeFoodButton.onClick.AddListener(OnConsumeFoodButtonClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
			_consumeFoodButton.onClick.RemoveListener(OnConsumeFoodButtonClicked);
		}

		void OnConsumeFoodButtonClicked()
		{
			ConsumeFoodButtonClicked?.Invoke();
		}
		
		public void SetCurrentCombatPower(int combatPower)
		{
			_currentCombatPowerText.text = combatPower.ToString();
		}
		
		public void SetNextLevelCombatPower(int combatPower)
		{
			_nextLevelCombatPowerText.text = combatPower.ToString();
		}
		
		public void SetStatus(SoldierStatus currentStatus, SoldierStatus nextStatus)
		{
			_statusUpgradeList.UpdateStatus(currentStatus, nextStatus);
		}

		public void SetCurrentLevel(int level)
		{
			_currentLevelText.text = level.ToString();
			_nextLevelText.text = (level + 1).ToString();
		}
		
		public void SetCurrentExperience(int experience)
		{
			_experienceSlider.value = experience;
			_currentExperienceText.text = experience.ToString();
		}
		
		public void SetTargetExperience(int experience)
		{
			_experienceSlider.maxValue = experience;
			_targetExperienceText.text = experience.ToString();
		}
		
		public void SetConsumeFoodAmount(int amount)
		{
			_consumeFoodAmountText.text = amount.ToString();
		}
	}

}