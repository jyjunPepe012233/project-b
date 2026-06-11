using AssetValidator;
using ProjectB.UI.Views.Common;
using UnityEngine;

namespace ProjectB.UI.Views.Buttons
{

	public class PlayerInfoLabelView : ButtonView
	{
		[SerializeField] private TextView _playerNameView;
		[SerializeField] private IntValueView _levelView;
		[SerializeField] private ProgressBarView _experienceProgressBarView;

		public void Initialize(string playerName,
			int level,
			int experience,
			int targetExperience)
		{
			SetPlayerName(playerName);
			SetLevel(level);
			SetExperienceProgress(experience, targetExperience);
		}

		public void SetPlayerName(string playerName)
		{
			_playerNameView.SetText(playerName);
		}

		public void SetLevel(int level)
		{
			_levelView.SetValue(level);
		}

		public void SetExperienceProgress(int experience, int targetExperience)
		{
			_experienceProgressBarView.SetProgress(experience, targetExperience);
		}

		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("PlayerNameView 할당", () => _playerNameView != null)
				.Register("LevelView 할당", () => _levelView != null)
				.Register("ExperienceProgressBarView 할당", () => _experienceProgressBarView != null);
		}
	}

}
