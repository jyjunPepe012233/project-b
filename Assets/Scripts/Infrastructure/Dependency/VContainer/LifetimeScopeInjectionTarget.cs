using ProjectB.Infrastructure.Dependency.Types;
using UnityEngine;
using VContainer.Unity;

namespace ProjectB.Infrastructure.Dependency
{
	
	// 이 클래스를 상속받아 사용하면
	// Inspector에서 LifetimeScope 타입을 선택하여 그 LifetimeScope에게 직접 Inject받을 수 있음

	public class LifetimeScopeInjectionTarget : MonoBehaviour
	{
		[SerializeField]
		protected LifetimeScopeReference _reference;

		private LifetimeScope _lifetimeScope;

		protected virtual void Start()
		{
			if (_reference.IsValid())
			{
				Object obj = FindObjectOfType(_reference.Type);
				
				if (obj is LifetimeScope lifetimeScope)
				{
					_lifetimeScope = lifetimeScope;
					_lifetimeScope.Container.Inject(this);
					OnInjected();
				}
				else
				{
					Debug.LogError("LifetimeScopeInjectionTarget: 대상을 찾을 수 없음: " + _reference.Type.FullName);
				}
			}
		}

		protected virtual void OnInjected()
		{
			
		}
	}

}