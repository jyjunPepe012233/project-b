using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.Data.Types;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Misc;
using UnityEngine;

namespace ProjectB.UI.Views.Pages.SoldierDetail
{

	public class SoldierDetailLevelUpPageView : TopElementView
	{
		[Required, SerializeField] private IntValueCompareView _levelCompareView;
		[Required, SerializeField] private ProgressBarView _experienceProgressBarView;
		[Required, SerializeField] private IntValueCompareView _combatPowerCompareView;
		[Required, SerializeField] private StatusCompareSetView _statusCompareSetView;
		
		[Required, SerializeField] private ButtonView _consumeFoodButton;
		[Required, SerializeField] private TextView _consumeFoodAmountTextView;
		
		public ButtonView ConsumeFoodButton => _consumeFoodButton;

		public void Initialize(int currentLevel, int nextLevel,
			int currentExperience, int targetExperience,
			int currentCombatPower, int nextCombatPower,
			SoldierStatus currentStatus, SoldierStatus nextStatus,
			int consumeFoodAmount)
		{
			SetLevelCompare(currentLevel, nextLevel);
			SetExperienceProgress(currentExperience, targetExperience);
			SetCombatPowerCompare(currentCombatPower, nextCombatPower);
			SetStatusCompareSet(currentStatus, nextStatus);
			SetConsumeFoodAmount(consumeFoodAmount);
		}
		
		public void SetLevelCompare(int currentLevel, int nextLevel)
		{
			_levelCompareView.SetStatusCompare(currentLevel, nextLevel);
		}
		
		public void SetExperienceProgress(int currentExperience, int targetExperience)
		{
			_experienceProgressBarView.SetProgress(currentExperience, targetExperience);
		}
		
		public void SetCombatPowerCompare(int currentCombatPower, int nextCombatPower)
		{
			_combatPowerCompareView.SetStatusCompare(currentCombatPower, nextCombatPower);
		}
		
		public void SetStatusCompareSet(SoldierStatus currentStatus, SoldierStatus nextStatus)
		{
			_statusCompareSetView.Initialize(currentStatus, nextStatus);
		}
		
		public void SetConsumeFoodAmount(int foodAmount)
		{
			_consumeFoodAmountTextView.SetText(foodAmount.ToString());
		}

		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("LevelCompareView", () => _levelCompareView != null)
				.Register("ExperienceProgressBarView", () => _experienceProgressBarView != null)
				.Register("CombatPowerCompareView", () => _combatPowerCompareView != null)
				.Register("StatusCompareSetView", () => _statusCompareSetView != null)
				.Register("ConsumeFoodButton", () => _consumeFoodButton != null)
				.Register("ConsumeFoodAmountTextView", () => _consumeFoodAmountTextView != null);
		}
	}

}