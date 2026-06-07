using System.Collections;
using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.Core.Supports;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.Playables;

namespace ProjectB.UI.Views.Media
{

	public class PlayableView : UIView
	{
		[Required, SerializeField] private PlayableDirector _playableDirector;
		
		private bool _isAnimating;
		
		IEnumerator WaitUntilTimelineFinish(PlayableAsset asset)
		{
			if (_isAnimating)
			{
				Debug.Log("PlayableView: 진행 중이던 애니메이션을 중지하고 새로운 애니메이션을 재생함. " + TransformDebug.GetHierarchyPath(transform));
				_playableDirector.Stop();
			}
		
			_isAnimating = true;
		
			_playableDirector.Play(asset);
			yield return new WaitForSeconds((float)asset.duration);

			_isAnimating = false;
		}
		
		public IEnumerator Play(PlayableAsset asset)
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