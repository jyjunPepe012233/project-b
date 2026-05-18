using UnityEngine;

namespace ProjectB.Core.Supports
{

	public static class CanvasGroupExtension
	{
		public static void SetVisible(this CanvasGroup canvasGroup, bool isVisible)
		{
			canvasGroup.alpha = isVisible ? 1 : 0;
			canvasGroup.interactable = isVisible;
			canvasGroup.blocksRaycasts = isVisible;
		}
	}

}