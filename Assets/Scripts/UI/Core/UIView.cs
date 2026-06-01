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

		protected virtual void Awake()
		{
			
		}
		
		protected virtual void Start()
		{
			if (defaultDisable)
			{
				Hide(); // Default Disable로 설정되어 있으면 초기 상태를 Hide로 설정
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