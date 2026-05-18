using System;
using ProjectB.Data.Types;
using ProjectB.UI.Lists.SoldierStatusList;
using ProjectB.UI.Parts;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Screens.SoldierDetailScreen
{

	[Serializable]
	public class InfoPageView : SoldierDetailPageView
	{
		[Header("Level")]
		[SerializeField] private TextMeshProUGUI _levelText;
		
		[Header("Rank")]
		[SerializeField] private StarProgress _rankStarProgress;
		
		[Header("Combat Power")]
		[SerializeField] private TextMeshProUGUI _combatPowerText;

		[Header("Status")]
		[SerializeField] private SoldierStatusListPresenter _statusList;
		
		public void SetLevel(short level)
		{
			_levelText.text = level.ToString();
		}
		
		public void SetRank(byte rank)
		{
			_rankStarProgress.SetStarCount(rank);
		}
		
		public void SetCombatPower(int combatPower)
		{
			_combatPowerText.text = combatPower.ToString();
		}

		public void SetStatus(SoldierStatus status)
		{
			_statusList.UpdateStatus(status);
		}
		
		// info page 만들기
		// 정보 페이지 다 만들면 상점 & 배낭 만들기
	}

}