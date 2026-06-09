using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.Data.Types;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Misc;
using UnityEngine;

namespace ProjectB.UI.Views.Pages.SoldierDetail
{

	public class SoldierDetailInfoPageView : TopElementView
	{
		[Required, SerializeField] private IconView _originIconView;
		[Required, SerializeField] private StarProgressView _rankProgressView;
		[Required, SerializeField] private IntValueView _levelView;
		[Required, SerializeField] private IntValueView _combatPowerView;
		[Required, SerializeField] private StatusSetView _statusSetView;
		
		public void Initialize(GameObject originIcon,
			int rank,
			int level,
			int combatPower,
			SoldierStatus status)
		{
			SetOriginIcon(originIcon);
			SetRankProgress(rank);
			SetLevel(level);
			SetCombatPower(combatPower);
			SetStatusSet(status);
		}
		
		public void SetOriginIcon(GameObject icon)
		{
			_originIconView.SetIcon(icon);
		}
		
		public void SetRankProgress(int rank)
		{
			_rankProgressView.SetStarCount(rank);
		}
		
		public void SetLevel(int level)
		{
			_levelView.SetValue(level);
		}
		
		public void SetCombatPower(int combatPower)
		{
			_combatPowerView.SetValue(combatPower);
		}
		
		public void SetStatusSet(SoldierStatus status)
		{
			_statusSetView.Initialize(status);
		}

		
		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("OriginIconView", () => _originIconView != null)
				.Register("RankProgressView", () => _rankProgressView != null)
				.Register("LevelView", () => _levelView != null)
				.Register("CombatPowerView", () => _combatPowerView != null)
				.Register("StatusSetView", () => _statusSetView != null);
		}
	}

}