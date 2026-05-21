using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIConstraint
{

	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	public class UIConstraintRoot : UIBehaviour, ILayoutController
	{
#if UNITY_EDITOR // OnValidate() 메서드에서 Dirty처리를 할지 여부에 대한 플래그이므로, 에디터에서만 컴파일되도록 처리
		[SerializeField] private bool _dirtyOnValidate = true;  
#endif
		[SerializeField] private bool _dirtyOnEnable = true; 
		[SerializeField] private bool _dirtyOnDisable = true;
		[SerializeField] private bool _dirtyOnParentChange = true;
		[SerializeField] private bool _dirtyOnChildrenChange = true;
		[SerializeField] private bool _dirtyOnRectTransformChange = true;
			
		
		private RectTransform _rectTransform;
		private RectTransform RectTransform
		{
			get
			{
				if (_rectTransform == null)
					_rectTransform = GetComponent<RectTransform>();
				return _rectTransform;
			}
		}

		// FindAllChildElements() 메서드에서 객체가 할당됨
		private readonly List<IUIConstraintElement> _elements = new();
		
		
		// ContentSizeFitter의 SetDirty()와 같은 패턴임
		// UI가 활성화되어있으면 이 rectTransform을 LayoutRebuilder에 레이아웃을 맞추라고 dirty 처리를 함 (MarkLayoutForRebuild)
		void SetDirty()
		{
			if (!IsActive()) // IsActive(): 게임오브젝트와 컴포넌트가 모두 활성화되어있는지
				return;
			
			foreach (var e in _elements)
			{
				try
				{
					// UI Element 내부에서 발생하는 에러 때문에 전체 흐름이 멈추는 것을 막기 위해 Try catch 사용
					e.ApplyConstraint();	
				}
				catch (Exception ex)
				{
					Debug.LogError($"UIConstraintRoot가 Element의 에러를 감지함: {ex.Message}\n{e}");
				}
			}

			LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
		}

		void FindAllChildElements()
		{ 
			GetComponentsInChildren<IUIConstraintElement>(false, _elements);
		}
		
		
#if UNITY_EDITOR
		protected override void OnValidate()
		{
			if (_dirtyOnValidate)
			{
				SetDirty(); // LayoutRebuilder가 이 컴포넌트가 있는 RectTransform의 레이아웃을 rebuild하도록 dirty 처리	
			}
		}
#endif

		protected override void OnEnable()
		{ 
			FindAllChildElements();
			
			base.OnEnable();
			if (_dirtyOnEnable)
			{
				SetDirty();
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();

			// UI가 비활성화될때는 활성화 여부와 관계 없이 Layout을 갱신할 필요가 있으므로 SetDirty()를 사용하지 않고 LayoutRebuilder를 즉시 호출함
			if (_dirtyOnDisable)
			{
				LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
			}
		}

		protected override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			if (_dirtyOnParentChange)
			{
				SetDirty(); // 부모가 바뀌면 레이아웃이 달라질 수 있으므로 dirty 처리
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			if (_dirtyOnRectTransformChange)
			{ 
				SetDirty(); // RectTransform의 크기가 바뀌면 레이아웃이 달라질 수 있으므로 dirty 처리
			}
		}


		protected virtual void OnTransformChildrenChanged()
		{
			FindAllChildElements();
			
			if (_dirtyOnChildrenChange)
			{
				SetDirty(); // 자식이 바뀌면 레이아웃이 달라질 수 있으므로 dirty 처리
			}
		}
		

		public void SetLayoutHorizontal() {}

		public void SetLayoutVertical() {}
	}

}