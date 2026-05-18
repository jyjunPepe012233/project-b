using ProjectB.Data.Static.Invasion;
using ProjectB.UI.Buttons.StageInfoButton;
using ProjectB.UI.Modals.StageInfoModal;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Screens.WorldMapScreen
{

	public class WorldMapScreenController : MonoBehaviour
	{
		[SerializeField] private string _chapterNameFormat = "침략 ({0})";
		[SerializeField] private TextMeshProUGUI _chapterNameText;
	
		[SerializeField] private StageInfoModalPresenter _stageInfoModalRight;
		[SerializeField] private StageInfoModalPresenter _stageInfoModalLeft;

		private IStageData _lastStageData;
	
		public void Awake()
		{
			StageInfoButtonEvents.Clicked += OnStageInfoButtonClicked;
		}

		public void OnDestroy()
		{
			StageInfoButtonEvents.Clicked -= OnStageInfoButtonClicked;
		}

		private void OnStageInfoButtonClicked(IStageData stage, bool isRightSide) // isRightSide: 버튼이 오른쪽에 있는지 여부
		{
			if (_stageInfoModalRight.IsShowing || _stageInfoModalLeft.IsShowing)
			{
				_stageInfoModalRight.Hide();
				_stageInfoModalLeft.Hide();

				if (_lastStageData != stage)
				{
					_lastStageData = stage;
					OpenStageInfoModal(stage, isRightSide);
				}
				else
				{
					_lastStageData = null;
				}
			}
			else
			{
				_lastStageData = stage;
				OpenStageInfoModal(stage, isRightSide);
			}
		}
	
		private void OpenStageInfoModal(IStageData stage, bool isRightSide)
		{
			var stageModal = isRightSide ? _stageInfoModalLeft : _stageInfoModalRight;
		
			stageModal.InitializeStageInfo(stage);
			stageModal.Show();
		
			_lastStageData = stage;
		}
	
		public void InitializeChapter(IChapterData chapter)
		{
			UpdateChapterName(chapter.ChapterName);
		}
	
		private void UpdateChapterName(string chapterName)
		{
			_chapterNameText.text = string.Format(_chapterNameFormat, chapterName);
		}
	}

}
