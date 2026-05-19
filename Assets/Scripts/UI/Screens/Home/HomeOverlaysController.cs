using System;
using System.Collections.Generic;
using System.Linq;
using InspectorGadgets.Attributes;
using ProjectB.Core.Types;
using UnityEngine;

namespace ProjectB.UI.Screens.Home
{

	public class HomeOverlaysController : MonoBehaviour
	{
		public static Action<string> OpenOverlay; // string: overlayID
		public static Action CloseOverlay; // string: overlayID
		
		[Inspectable(Readonly = true)]
		public static string CurrentOverlayID { get; private set; }
		
		
		
		[SerializeField]
		private InterfaceRefs<IHomeFullScreenOverlay> _overlays; // 인스펙터에서 오버레이의 ID와 오버레이를 등록할 수 있도록 함


		private Dictionary<string, IHomeFullScreenOverlay> _overlayTable; // Awake()에서 할당됨
		private readonly Stack<IHomeFullScreenOverlay> _overlayStack = new(2);



		private void Awake()
		{
			// 정적 이벤트 구독
			OpenOverlay += OnOpenOverlay;
			CloseOverlay += OnCloseOverlay;
			
			
			// _initialOverlays 배열을 딕셔너리로 만들어 _screens에 저장
			_overlayTable = _overlays.Value.Select(overlay =>
			{
				if (overlay == null)
				{
					Debug.LogError($"[{nameof(HomeOverlaysController)}] 오버레이가 null임");
					return default;
				}
				
				if (string.IsNullOrEmpty(overlay.OverlayID))
				{
					Debug.LogError($"[{nameof(HomeOverlaysController)}] OverlayID가 비어있음");
					return default;
				}

				return new KeyValuePair<string, IHomeFullScreenOverlay>(overlay.OverlayID, overlay);
			}).ToDictionary(pair => pair.Key, pair => pair.Value);
			
			
			
			// 초기에는 모든 오버레이를 숨김
			foreach (var overlay in _overlayTable.Values)
			{
				overlay.Hide();
			}
		}
		
		
		
		void OnOpenOverlay(string overlayID)
		{
			if (!_overlayTable.ContainsKey(overlayID))
			{
				Debug.LogError($"[{nameof(HomeOverlaysController)}] 등록되지 않은 OverlayID: {overlayID}");
				return;
			}
			
			// 켜져있는 오버레이가 있으면 숨김
			if (_overlayStack.Count != 0)
			{
				IHomeFullScreenOverlay currentOverlay = _overlayStack.Peek();
				currentOverlay.Hide();
				CurrentOverlayID = null;
			}
			
			IHomeFullScreenOverlay overlay = _overlayTable[overlayID];
		
			_overlayStack.Push(overlay);
			overlay.Open();
			CurrentOverlayID = overlay.OverlayID;
		}

		void OnCloseOverlay()
		{
			if (_overlayStack.Count == 0)
			{
				Debug.LogWarning($"[{nameof(HomeOverlaysController)}] 닫을 Overlay가 없음");
				return;
			}
		
			IHomeFullScreenOverlay overlay = _overlayStack.Pop();
			overlay.Close();
			CurrentOverlayID = null;
		
			if (_overlayStack.Count != 0)
			{
				IHomeFullScreenOverlay nextOverlay = _overlayStack.Peek();
				nextOverlay.Show();
				CurrentOverlayID = nextOverlay.OverlayID;
			}
		}
	}

}
