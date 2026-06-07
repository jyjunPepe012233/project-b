using System.Collections;
using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;

namespace ProjectB.UI.Views.Media
{

	public class SummonAnimationView : UIView
	{
		[Required, SerializeField] private VideoPlayer _videoPlayer;
		[Required, SerializeField] private PlayableView _playableView;
		
		public IEnumerator PlayAnimation(PlayableAsset asset)
		{
			_videoPlayer.Play();
			yield return _playableView.Play(asset);
		}

		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("VideoPlayer 할당", () => _videoPlayer != null)
				.Register("PlayableView 할당", () => _playableView != null);
		}
	}

}