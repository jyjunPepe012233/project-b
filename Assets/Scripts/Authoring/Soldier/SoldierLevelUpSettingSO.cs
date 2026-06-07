using ProjectB.Data.Static.Soldier;
using UnityEngine;

namespace ProjectB.Authoring.Soldier
{

	[CreateAssetMenu(menuName = "Project B/Soldier/Level Up Setting")]
	public class SoldierLevelUpSettingSo : UnityEngine.ScriptableObject, ISoldierLevelUpSetting
	{
		[Header("인덱스+1 이 레벨입니다")]
		[SerializeField] private int[] _levelUpCosts;

		public int GetLevelUpExpOfLevel(int level)
		{
			if (_levelUpCosts.Length == 0)
			{
				return 100;
			}
			
			// 레벨이 배열을 초과하면 마지막 요소를 전달함
			if (level >= _levelUpCosts.Length)
			{
				return _levelUpCosts[^1];
			}
			
			return _levelUpCosts[level - 1];
		}
	}

}