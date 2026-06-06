using System.Collections;
using System.Collections.Generic;
using ProjectB.Gameplay.Internal.Ports.Overlay;
using UnityEngine;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public class OverlayManager : IOverlayManager
	{
		private readonly Stack<IOverlayController> _overlayStack = new Stack<IOverlayController>();
		
		public IEnumerator Open(IOverlayController overlayController)
		{
			// 뒤로 밀려난 Overlay를 Hide
			if (_overlayStack.Count > 0)
			{
				var topOverlay = _overlayStack.Peek();
				if (topOverlay == overlayController)
				{
					Debug.LogWarning("OverlayManager: 이미 열려있는 Overlay를 다시 열려고 시도했습니다.");
					yield break;
				}
				
				yield return topOverlay.Hide();
			}
			
			_overlayStack.Push(overlayController);
			yield return overlayController.Open(); // 실제로 Overlay를 열 때 OnOpen 호출
		}

		public IEnumerator Close()
		{
			if (_overlayStack.Count == 0)
			{
				Debug.LogWarning("OverlayManager: 닫을 Overlay가 없습니다.");
				yield break;
			}
			
			var topOverlay = _overlayStack.Pop();
			yield return topOverlay.Close(); // 실제로 Overlay를 닫을 때 OnClose 호출
			
			// Stack 최상단으로 올라온 Overlay가 있다면 Show
			if (_overlayStack.Count > 0)
			{
				yield return _overlayStack.Peek().Show();
			}
		}

		public IEnumerator CloseAll()
		{
			while (_overlayStack.Count > 0)
			{
				var topOverlay = _overlayStack.Pop();
				yield return topOverlay.Close(); // 실제로 Overlay를 닫을 때 OnClose 호출
			}
		}
	}

}