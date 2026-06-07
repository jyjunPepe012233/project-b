using System.Collections.Generic;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using UnityEngine;

namespace ProjectB.Authoring.Invasion
{

	[CreateAssetMenu(menuName = "Project B/Invasion/Chapter")]
	public class ChapterSO : UnityEngine.ScriptableObject, IChapterData
	{
		[SerializeField] private string _chapterName;
		public string ChapterName => _chapterName;
	
		[SerializeField] private InterfaceRefs<IStageData> _stages;
		public IReadOnlyCollection<IStageData> Stages => _stages.Value;
	}

}
