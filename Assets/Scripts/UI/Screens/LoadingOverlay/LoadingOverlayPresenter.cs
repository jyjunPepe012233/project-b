using System.Collections;
using ProjectB.UI.Core;

namespace ProjectB.UI.Screens.LoadingOverlay
{

	public class LoadingOverlayPresenter : UIPresenter<LoadingOverlayView>
	{
		public IEnumerator OpenTransition()
		{
			yield return view.OpenTransitionCoroutine();
		}
		
		public IEnumerator CloseTransition()
		{
			yield return view.CloseTransitionCoroutine();
		}
	}

}
