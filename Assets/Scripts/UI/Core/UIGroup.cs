using System.Linq;
using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.Core.Supports;
using UnityEngine;

namespace ProjectB.UI.Core
{

	public class UIGroup : MonoBehaviour, IValidatable
	{
		[Required, SerializeField]
		private CanvasGroup _canvasGroup;
		
		[SerializeField]
		private BaseUIPresenter[] _childUIPresenters;
		
		[SerializeField, Readonly]
		private bool _isShowing;
		public bool IsShowing => _isShowing;
		
		
#if UNITY_EDITOR

		[Button(SetDirty = true)]
		public void SetupCanvasGroup()
		{
			if (_canvasGroup == null)
			{
				_canvasGroup = GetComponent<CanvasGroup>();
				if (_canvasGroup == null)
				{
					_canvasGroup = gameObject.AddComponent<CanvasGroup>();
				}

				// 프리팹에도 변경 사항을 반영
				UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(this);
			}
		}
		
		// 에디터에서 버튼을 눌러 자식 UI Presenter들을 자동으로 할당하는 메서드
		[Button(SetDirty = true)]
		public void SetupChildUI()
		{
			_childUIPresenters = GetComponentsInChildren<BaseUIPresenter>(false)
				.Where(p => p.gameObject != gameObject && p.transform.IsChildOf(transform)) // 자신을 포함시키면 논리적 재귀가 형성되므로 제외
				.ToArray();
			
			// 프리팹에도 변경 사항을 반영
			UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(this);
		}
#endif

		public void Show()
		{
			if (_canvasGroup == null)
			{
				Debug.LogWarning("UIGroup: CanvasGroup이 할당되지 않았습니다. Group: " + TransformDebug.GetHierarchyPath(transform));;
			}
			_canvasGroup.SetVisible(true);

			
			foreach (var presenter in _childUIPresenters)
			{
				if (presenter == null)
				{
					Debug.LogWarning("UIGroup: 자식 Presenter 요소 중 하나가 Null입니다. Group: " + TransformDebug.GetHierarchyPath(transform));
					continue;
				}
				presenter.Show();
			}
		}
		
		public void Hide()
		{
			if (_canvasGroup == null)
			{
				Debug.LogWarning("UIGroup: CanvasGroup이 할당되지 않았습니다. Group: " + TransformDebug.GetHierarchyPath(transform));
			}
			_canvasGroup.SetVisible(false);
			
			
			foreach (var presenter in _childUIPresenters)
			{
				if (presenter == null)
				{
					Debug.LogWarning("UIGroup: 자식 Presenter 요소 중 하나가 Null입니다 Group: " + TransformDebug.GetHierarchyPath(transform));
					continue;
				}
				presenter.Hide();
			}
		}
		
		
		
		// IValidatable 구현
		public MonoBehaviour GetMonoBehaviour() => this;

		public ValidationMethod GetValidationMethod()
		{
			return new ValidationMethod()
				.Register("CanvasGroup 할당", () => _canvasGroup != null)
				.Register("자식 Presenter 요소 중 Null 존재 여부 검증",
					() => _childUIPresenters?.All(p => p != null) ?? true); // _childUIPresenter가 null이면 유효한 상태임(요소가 없음)ㄴ
		}
	}

}