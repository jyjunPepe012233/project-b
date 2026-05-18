using System;
using MonoBehaviourValidator;
using ProjectB.Core.Supports;
using UnityEngine;

namespace ProjectB.UI.Core
{
	
	// UI를 구현할 때는 UIPresenter를 상속받아서 구현하면 됨.
	// 제네릭 없이 추상적으로 참조하고 싶을 때는 BaseUIPresenter로 참조하면 됨.
	public abstract class UIPresenter<TView> : BaseUIPresenter, IValidatable where TView : UIView
	{
		[SerializeField] protected TView view;

		[Header("Settings")]
		[SerializeField] protected bool defaultDisable = false;
		[SerializeField] protected bool dontDestroyOnLoad = false;
		[SerializeField] protected bool initializeOnShow = true;
		
		public bool IsShowing => view.IsShowing;

		public void Awake()
		{
			view.RegisterUICallbacks();
			
			if (dontDestroyOnLoad)
			{
				DontDestroyOnLoad(gameObject);
			}
		}

		public void Start()
		{
			SetupReferences();
			SetupSubscriptions();
			InitializeView();

			if (defaultDisable)
			{ 
				view.Hide();
			}
		}
	
		public void OnDestroy()
		{
			view.Dispose();
			DisposeSubscriptions();
		}

		protected virtual void SetupReferences()
		{
			
		}
	
		protected virtual void SetupSubscriptions()
		{
		
		}

		protected virtual void DisposeSubscriptions()
		{
		
		}
	
		protected virtual void InitializeView()
		{
		
		}
		
		
		public override void Show()
		{
			// UI 단위로 예외 처리를 해서 전체 UI 시스템이 멈추는 것을 방지함
			try
			{
				if (initializeOnShow)
				{
					InitializeView();
				}

				view.Show();
			}
			catch (Exception e)
			{
				Debug.LogError($"() 중 예외 발생\nUI: {TransformDebug.GetHierarchyPath(transform)}\n\n{e}");
			}
		}
		
		public override void Hide()
		{
			try
			{
				view.Hide();
			}
			catch (Exception e)
			{
				Debug.LogError($"Hide() 중 예외 발생\nUI: {TransformDebug.GetHierarchyPath(transform)}\n\n{e}");
			}
		} 
		
		
		
		// IValidatable 구현
		public MonoBehaviour GetMonoBehaviour() => this;

		public ValidationMethod GetValidationMethod()
		{
			return new ValidationMethod()
				.Register("View에 UIGroup 할당", () => view.UIGroup != null);
		}
	}

}
