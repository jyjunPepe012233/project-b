using ProjectB.Data.Static.Player;
using UnityEngine;

namespace ProjectB.Infrastructure.Authoring.Player
{

	[CreateAssetMenu(menuName = "Project B/Player/Level Up Setting")]
	public class PlayerLevelUpSettingSO : UnityEngine.ScriptableObject, IPlayerLevelUpSetting
	{
		[SerializeField] private int _maxLevel;
		public int MaxLevel => _maxLevel;

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
				Debug.LogWarning($"설정되지 않은 레벨(Lv {level})의 비용이 임의로 생성되어 반환되었습니다");
				return _levelUpCosts[^1];
			}

			return _levelUpCosts[level - 1];
		}
	}

}
