using System.Linq;
using InspectorGadgets.Attributes;
using ProjectB.Core.Supports;
using ProjectB.Core.Types;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.Home
{
	public class HomeFullScreenOverlay : MonoBehaviour, IHomeFullScreenOverlay
	{
		[Required, SerializeField]
		private CanvasGroup _canvasGroup;
	
		[Required, SerializeField]
		private string _overlayID;
		public string OverlayID => _overlayID;
		
		[SerializeField]
		private InterfaceRefs<IUIPresenter> _childUIPresenters;

		
#if UNITY_EDITOR
		
		// 에디터에서 버튼을 눌러 자식 UI Presenter들을 자동으로 할당하는 메서드
		[Button]
		public void SetupChildUI()
		{
			_childUIPresenters = new InterfaceRefs<IUIPresenter>(GetComponentsInChildren<IUIPresenter>()
				.Select(presenter => (Object)presenter) // GetComponentsInChild로 받아온 객체들이라 Object로 캐스팅 가능함
				.ToArray());
			
			// 변경 사항을 에디터에서 반영
			UnityEditor.EditorUtility.SetDirty(this);
			UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(this);
		}
#endif
	
		public void Open()
		{
			if (_canvasGroup == null)
			{
				Debug.LogWarning($"[{nameof(HomeFullScreenOverlay)}] CanvasGroup이 할당되지 않았습니다.");
			}
			_canvasGroup.SetVisible(true);

			
			foreach (var presenter in _childUIPresenters.Value)
			{
				presenter.Show();
			}
		}

		public void Hide()
		{
			if (_canvasGroup == null)
			{
				Debug.LogWarning($"[{nameof(HomeFullScreenOverlay)}] CanvasGroup이 할당되지 않았습니다.");
			}
			_canvasGroup.SetVisible(false);
			
			
			foreach (var presenter in _childUIPresenters.Value)
			{
				presenter.Hide();
			}
		}

		public void Show()
		{
			if (_canvasGroup == null)
			{
				Debug.LogWarning($"[{nameof(HomeFullScreenOverlay)}] CanvasGroup이 할당되지 않았습니다.");
			}
			_canvasGroup.SetVisible(true);
			
			
			foreach (var presenter in _childUIPresenters.Value)
			{
				presenter.Show();
			}
		}

		public void Close()
		{
			if (_canvasGroup == null)
			{
				Debug.LogWarning($"[{nameof(HomeFullScreenOverlay)}] CanvasGroup이 할당되지 않았습니다.");
			}
			_canvasGroup.SetVisible(false);
			
			
			foreach (var presenter in _childUIPresenters.Value)
			{
				presenter.Hide();
			}
		}
	}

}