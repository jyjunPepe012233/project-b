using ProjectB.Core.Supports;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Gameplay.Events;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Inbound.Ports.Overlay;
using ProjectB.UI.Views.Buttons;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Media;
using UnityEngine.Playables;

namespace ProjectB.UI.Presenters.Overlays
{

	public class SummonAnimationOverlayPresenter : BaseOverlayPresenter<SummonAnimationOverlayEvents>
	{
		private readonly SummonAnimationView _summonAnimationView;
		private readonly PlayableAsset _summonAnimationAsset;
		
		private readonly SummonAnimationEvents _summonAnimationEvents;

		public SummonAnimationOverlayPresenter(TopElementView topElementView,
			ButtonView closeButtonView,
			SummonAnimationOverlayEvents overlayEvents,
			IOverlayStackService overlayStackService,
			SummonAnimationView summonAnimationView,
			PlayableAsset summonAnimationAsset,
			SummonAnimationEvents summonAnimationEvents) : base(topElementView, closeButtonView, overlayEvents, overlayStackService)
		{
			_summonAnimationView = summonAnimationView;
			_summonAnimationAsset = summonAnimationAsset;
			_summonAnimationEvents = summonAnimationEvents;
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_summonAnimationEvents.StartAnimation += OnStartAnimation;
		}
		
		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_summonAnimationEvents.StartAnimation -= OnStartAnimation;
		}
		
		void OnStartAnimation(SummonResult summonResult)
		{
			// 이후 확장을 위해 summonResultEvents를 인자로 받기는 하나,
			// 현재는 뽑기 결과에 상관 없이 모두 같은 애니메이션이 재생되므로 사용하지는 않음
			
			CoroutineHandler.StartAndAdd(_summonAnimationView.PlayAnimation(_summonAnimationAsset));
		}
	}

}