using AssetValidator;
using Coffee.UIExtensions;
using InspectorGadgets.Attributes;
using UnityEngine;

namespace ProjectB.GameObjects.Effects
{

	public class ScreenClickEffect : MonoBehaviour, IValidatable
	{
		
		// 카메라 자동 할당 비활성화 여부
		// 이 기능이 없으면 씬이 바뀌었을 때 카메라가 파괴되어 작동하지 않으므로
		// 정상적인 기능 작동을 위해서는 false인 채로 둘 것
		[SerializeField] private bool _disableAutoFindCamera = false;
		
		[SerializeField] private Camera _camera;
		[Required, SerializeField] private UIParticle _clickEffect;

		public void Awake()
		{
			DontDestroyOnLoad(transform);
			DontDestroyOnLoad(_clickEffect.gameObject);
			
			if (!_disableAutoFindCamera && _camera == null)
			{
				_camera = Camera.main;
			}
		}

		public void Update()
		{
			if (_camera == null)
			{
				if (_disableAutoFindCamera)
				{
					return;
				}
				
				_camera = Camera.main;
				if (_camera == null)
				{
					return;
				}
			}
			
			if (_clickEffect == null)
			{
				return;
			}

#if UNITY_EDITOR
			// 에디터에서는 마우스 클릭 사용
			if (Input.GetMouseButtonDown(0))
			{
				PlayClickEffect(Input.mousePosition);
			}
#else
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				
				if (touch.phase == TouchPhase.Began)
				{
					PlayClickEffect(touch.position);
				}
			}
#endif
		}
		
		
		// 상속 가능하도록 선언
		protected virtual void PlayClickEffect(Vector2 touchPos)
		{
			_clickEffect.transform.position = touchPos;
			_clickEffect.Play();
		}
		
		public MonoBehaviour GetMonoBehaviour()
		{
			return this;
		}

		public ValidationMethod GetValidationMethod()
		{
			return new ValidationMethod()
				.Register("Camera 할당", () => _camera != null)
				.Register("ClickEffect 할당", () => _clickEffect != null);
		}
	}

}