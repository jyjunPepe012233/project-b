using System;
using System.Collections;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;
using UnityEngine.Windows.WebCam;

namespace ProjectB.UI.Screens.SummonAnimationScreen
{
	
	[Serializable]
	public class SummonAnimationScreenView : UIView
	{
		[Required, SerializeField]
		private VideoPlayer _videoPlayer;
		
		[Required, SerializeField]
		private PlayableDirector _playableDirector;

		// 가비지 생성을 최소화하기 위해 재활용
		private WaitForSeconds _waitUntilTimelineFinish;
		
		
		
		public IEnumerator StartAnimation()
		{
			_videoPlayer.Play();
			_playableDirector.Play();

			if (_waitUntilTimelineFinish == null)
			{
				_waitUntilTimelineFinish = new WaitForSeconds((float)_playableDirector.duration); // double -> float
			}

			yield return _waitUntilTimelineFinish;
		}
	}

}