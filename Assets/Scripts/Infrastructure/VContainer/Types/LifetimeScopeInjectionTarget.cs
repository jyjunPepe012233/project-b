using System;
using ProjectB.Infrastructure.Dependency.Types;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace ProjectB.Infrastructure.Dependency
{
	
	// 이 클래스를 상속받아 사용하면
	// Inspector에서 LifetimeScope 타입을 선택하여 그 LifetimeScope에게 직접 Inject받을 수 있음

	public class LifetimeScopeInjectionTarget : MonoBehaviour
	{
		[SerializeField]
		protected LifetimeScopeReference _reference;

		private LifetimeScope _lifetimeScope;
		
		public bool IsInjected { get; private set; }

		protected virtual void Start()
		{
			// VContainer에서 Exception이 발생하면 프레임의 PlayerLoop 자체가 끊길 수 있으므로
			// 컴포넌트 단위로 예외처리하여 문제가 되는 컴포넌트만 영향을 받도록 함
			try
			{
				if (_reference.IsValid())
				{
					Object obj = FindObjectOfType(_reference.Type);

					if (obj is LifetimeScope lifetimeScope)
					{
						_lifetimeScope = lifetimeScope;
						_lifetimeScope.Container.Inject(this);
						IsInjected = true;
						OnInjected();
					}
					else
					{
						Debug.LogError("LifetimeScopeInjectionTarget: 대상을 찾을 수 없음: " + _reference.Type.FullName);
					}
				}
				
			} catch (Exception e)
			{
				Debug.LogError("Injection 실패: " + e);
			}
		}

		protected virtual void OnInjected()
		{
			
		}
	}

}