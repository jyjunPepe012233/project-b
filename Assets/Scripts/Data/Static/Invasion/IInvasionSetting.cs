using System.Collections.Generic;

namespace ProjectB.Data.Static.Invasion
{

	public interface IInvasionSetting
	{
		int ExperienceReward { get; }                                                  
		
		IReadOnlyCollection<IChapterData> Chapters { get; }
		
		void GetLevelsOfStage(IStageData stage, out int chapterLevel, out int stageLevel);
	}

}