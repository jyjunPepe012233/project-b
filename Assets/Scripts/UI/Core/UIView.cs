using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.Core.Supports;
using UnityEngine;

namespace ProjectB.UI.Core
{
	
	public abstract class UIView : MonoBehaviour, IValidatable
	{
		[SerializeField, Readonly] private bool _isShowing;
		public bool IsShowing => _isShowing;
		
		// 이 View가 Presenter나 상위 View에게 제어되는지 확인하기 위한 플래그
		// 이 클래스의 MarkAsControlled()가 호출되면 true로 설정됨
		[SerializeField, Readonly] private bool _isControlled;
		
		[Header("Settings")]
		[SerializeField] protected bool defaultDisable = false; // 페이지가 열릴 때 기본적으로 비활성화되어 있어야 하는지 여부

		
		[SerializeField, Required] protected CanvasGroup _canvasGroup;
		
		
		
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
#endif

		// Presenter나 상위 View가 이 UIView를 제어하는지 확인하기 위한 처리를 하는 메서드.
		// 다른 요소에게 제어되지 않는다고 판단되면, UIView가 자체적으로 Hide됨
		public void MarkAsControlled()
		{
			if (_isControlled)
			{
				Debug.LogWarning("UIView: 이미 제어되고 있는 UI입니다. UI: " + TransformDebug.GetHierarchyPath(transform));
				return;
			}
			
			_isControlled = true;
		}


		void Start()
		{
			if (_isControlled)
			{
				Show();
			}
			else
			{
				Debug.LogWarning("UIView: 제어되지 않는 UI가 자체적으로 Hide 처리되었습니다. UI: " + TransformDebug.GetHierarchyPath(transform));
				Hide();
			}
		}
		
		
		/// <param name="includeDefaultDisable">true라면 defaultDisable로 설정된 UI를 포함하고 Show함</param>
		public void Show(bool includeDefaultDisable = false)
		{
			if (defaultDisable && !includeDefaultDisable)
			{
				return; // Default Disable로 설정되어 있으면 UI 활성화를 하지 않음
			}
			
			_isShowing = true;
			
			// CanvasGroup 활성화 (실제로 보이게 하는 작업)
			if (_canvasGroup == null)
			{
				Debug.LogWarning("UIGroup: CanvasGroup이 할당되지 않았습니다. Group: " + TransformDebug.GetHierarchyPath(transform));;
			}
			else
			{
				_canvasGroup.SetVisible(true);
			}
			
			OnShowed();
			OnSetupUICallbacks(); // Show 시 UI 콜백 등록
		}
		
		public void Hide()
		{
			_isShowing = false;
			
			// CanvasGroup을 제어하여 실제로 보이지 않게 설정하는 작업
			if (_canvasGroup == null)
			{
				Debug.LogWarning("UIGroup: CanvasGroup이 할당되지 않았습니다. Group: " + TransformDebug.GetHierarchyPath(transform));
			}
			else
			{
				_canvasGroup.SetVisible(false);
			}
			
			OnHided();
			OnDisposeUICallbacks(); // Hide 시 UI 콜백 해제
		}

		// UIView를 상속받은 클래스에서 Show 시 처리해야하는 추가 작업이 있다면 여기서 구현하면 됨
		// 예를 들어, Show 시 SubView도 Show하는 작업은 여기서 구현하면 됨	
		protected virtual void OnShowed()
		{
			
		}

		// UIView를 상속받은 클래스에서 Hide 시 처리해야하는 추가 작업이 있다면 여기서 구현하면 됨
		// 예를 들어, Hide 시 SubView도 Hide하는 작업은 여기서 구현하면 됨
		protected virtual void OnHided()
		{
			
		}
		
		protected virtual void OnSetupUICallbacks()
		{
			
		}

		protected virtual void OnDisposeUICallbacks()
		{
			
		}
		
		
		
		// IValidatable로 캐스팅했을때만 메서드를 사용 가능하게 함
		MonoBehaviour IValidatable.GetMonoBehaviour() => this;

		
		// 위와 같이 IValidatable로 캐스팅 했을때만 사용 가능하도록 하고 싶지만,
		// 하위 클래스에서 메서드 override가 가능해야 하므로 public virtual로 선언
		public virtual ValidationMethod GetValidationMethod()
		{
			return new ValidationMethod()
				.Register("CanvasGroup 할당", () => _canvasGroup != null);
		}
	}
	
}