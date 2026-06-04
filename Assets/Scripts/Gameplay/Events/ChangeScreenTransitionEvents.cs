using System;

namespace ProjectB.Gameplay.Events
{

	public class ChangeScreenTransitionEvents
	{
		public Action StartFadeIn;

		// UI 측에서 호출하는 Fade-In 완료 신호
		public Action FadeInComplete;
		
		public Action StartFadeOut;
		
		// UI 측에서 호출하는 Fade-Out 완료 신호
		public Action FadeOutComplete;
	}

}