using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIConstraint
{

	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	public abstract class UIConstraintElementBehaviour
		: UIBehaviour, IUIConstraintElement // IUIConstraintElement 인터페이스를 구현하면 UIConstraintRoot에서 ApplyConstraint()가 호출됨
	{
		private RectTransform _rectTransform;
		protected RectTransform RectTransform
		{
			get
			{
				if (_rectTransform == null)
					_rectTransform = GetComponent<RectTransform>();
				return _rectTransform;
			}
		}
		
		private RectTransform _parentRectTransform;

		protected RectTransform ParentRectTransform
		{
			get
			{
				if (_parentRectTransform == null)
				{
					if (transform.parent != null)
						_parentRectTransform = transform.parent.GetComponent<RectTransform>();
				}
				return _parentRectTransform;
			}
		}
		
		// 하위 클래스는 tracker를 조작해서 UI 소유권을 할당받으면 됨
		protected DrivenRectTransformTracker tracker;
		
		
		
		void SetDirty()
		{
			if (!IsActive())
				return;
			
			LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
		}

		void ApplyConstraintWithEditorDelay()
		{
#if UNITY_EDITOR
			EditorApplication.delayCall += () =>
			{
				if (this != null)
				{
					ApplyConstraint();
					SetDirty(); // layout Rebuild도 지연 후 호출해야 재귀가 발생하지 않음. (재귀가 발생해도 UGUI 시스템이 알아서 중단하긴 하지만 어쨌거나 불필요한 재귀이므로 피하는 게 좋음)
				}
			};
#else
			ApplyConstraint(); // 런타임
#endif
		}

#if UNITY_EDITOR
		protected override void OnValidate()
		{
			ApplyConstraintWithEditorDelay();
		}
#endif

		protected override void OnEnable()
		{
			ApplyConstraintWithEditorDelay();
		}
		
		protected override void OnRectTransformDimensionsChange()
		{
			ApplyConstraintWithEditorDelay();
		}

		public virtual void ApplyConstraint() {}
	}

}