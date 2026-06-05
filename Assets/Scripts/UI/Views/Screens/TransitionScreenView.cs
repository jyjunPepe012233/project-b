using System.Collections;
using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.Playables;

namespace ProjectB.UI.Views.Screens
{

	public class TransitionScreenView : UIView
	{
		[Required, SerializeField] private PlayableDirector _playableDirector;
		
		private bool isAnimating;
		
		IEnumerator WaitUntilTimelineFinish(PlayableAsset asset)
		{
			if (isAnimating)
				yield return new WaitUntil(() => !isAnimating);
		
			isAnimating = true;
		
			_playableDirector.Play(asset);
			yield return new WaitForSeconds((float)asset.duration);

			isAnimating = false;
		}
		
		public IEnumerator PlayFadeIn(PlayableAsset asset)
		{
			yield return WaitUntilTimelineFinish(asset);
		}
		
		public IEnumerator PlayFadeOut(PlayableAsset asset)
		{
			yield return WaitUntilTimelineFinish(asset);
		}

		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("PlayableDirector 할당", () => _playableDirector != null);
		}
	}

}