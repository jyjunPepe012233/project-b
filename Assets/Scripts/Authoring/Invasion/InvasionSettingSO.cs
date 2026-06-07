using System.Collections.Generic;
using System.Linq;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using UnityEngine;

namespace ProjectB.Authoring.Invasion
{

	[CreateAssetMenu(menuName = "Project B/Invasion/Invasion Setting")]
	public class InvasionSettingSO : UnityEngine.ScriptableObject, IInvasionSetting
	{
		private static readonly Dictionary<IStageData, (int chapterLevel, int stageLevel)> _stageLevelsCache = new();
		
		
		[SerializeField] private int _experienceReward;
		public int ExperienceReward => _experienceReward;
		
		
		[SerializeField] private InterfaceRefs<IChapterData> _chapters;
		public IReadOnlyCollection<IChapterData> Chapters => _chapters.Value;
		
		
		
		public void GetLevelsOfStage(IStageData stage, out int chapterLevel, out int stageLevel)
		{
			if (_stageLevelsCache.TryGetValue(stage, out var levels))
			{
				chapterLevel = levels.chapterLevel;
				stageLevel = levels.stageLevel;
				return;
			}
			
			for (int i = 0; i < _chapters.Value.Count; i++)
			{
				// IReadOnlyCollection이라 인덱스로 접근할 수 없어서 ElementAt을 사용함
				var c = _chapters.Value.ElementAt(i);

				for (int j = 0; i < c.Stages.Count; j++)
				{
					var s = c.Stages.ElementAt(j);

					if (s == stage)
					{
						chapterLevel = i + 1; // 챕터 레벨은 1부터 시작하니 1 추가
						stageLevel = j + 1; // 스테이지 레벨도 1부터임
						_stageLevelsCache[stage] = (chapterLevel, stageLevel); // 캐시에 저장
						return;
					}
				}
			}
			
			// 스테이지를 찾지 못한 경우
			
			Debug.LogError("스테이지 레벨을 찾을 수 없습니다: " + stage.StageName);
			chapterLevel = 1;
			stageLevel = 1;
		}
	}

}
