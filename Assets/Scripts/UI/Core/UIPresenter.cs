using UnityEngine;

namespace ProjectB.UI.Core
{

	// UI Presenter는 연결된 UI View를 관리하는 MonoBehaviour임
	// 수동적 클래스인 UIView를 통일된 생명주기 상에서 관리하며, defaultDisable과 같은 여러 옵션을 제공함
	// 또, 이 클래스는 가능한 독립적, 자주적으로 작동해야 하며 다른 클래스에게 제어되지 않아야 함.
	// (다른 클래스에게 제어받아야 하는 UI는 UIPresenter를 상속한 UIComponet를 사용하면 됨)
	public abstract class UIPresenter<TView> : MonoBehaviour where TView : UIView
	{
		[SerializeField] protected TView view;

		[Header("Settings")]
		[SerializeField] protected bool defaultDisable = false;
		[SerializeField] protected bool dontDestroyOnLoad = false;
		[SerializeField] protected bool initializeOnEnable = true;
		
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

		public void OnEnable()
		{
			if (initializeOnEnable)
			{
				InitializeView();
			}
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
	}

}
