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
		
		protected override void Start()
		{
			base.Start();
			_videoPlayer.Prepare();
		}

		public override void Show(bool includeDefaultDisable = false)
		{
			// 열지 않음. 애니메이션이 재생될 때 Show하도록 함
//			base.Show(includeDefaultDisable);
		}

		public IEnumerator PlayAnimation(PlayableAsset asset)
		{
			base.Show(); // 애니메이션이 시작될 때 뷰를 보이도록 함

			_videoPlayer.time = 0;
			_videoPlayer.Play();
			yield return _playableView.Play(asset);
			
			// 다음 애니메이션이 지연 없이 재생될 수 있도록 미리 처음 프레임으로 대기
			_videoPlayer.Prepare();
		}

		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("VideoPlayer 할당", () => _videoPlayer != null)
				.Register("PlayableView 할당", () => _playableView != null);
		}
	}

}