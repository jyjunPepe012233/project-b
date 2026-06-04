using System;
using UnityEngine;
using VContainer.Unity;

namespace ProjectB.Infrastructure.Dependency.Types
{
	// LifetimeScope 타입을 참조하기 위한 구조체임
	// Property Drawer가 구현되어 있어, 이 구조체가 Inspector에 띄워지면 모든 LifetimeScope 타입을 선택 가능한 드롭다운 메뉴가 됨

	[Serializable]
	public struct LifetimeScopeReference : ISerializationCallbackReceiver
	{
		// 타입은 직렬화할 수 없으므로 TypeName을 저장함.
		// 이 구조체에는 역직렬화 과정에서 TypeName을 기반으로 Type을 찾는 처리가 포함되어 있음
		[SerializeField] private string _typeName;
		public string TypeName => _typeName; // 외부에서 읽을 수 있도록 노출
		
		
		// 런타임 과정에서만 사용하는 Type 필드
		// 역직렬화 과정에서 TypeName을 기반으로 Type이 탐색되어 여기에 할당됨
		public Type Type { get; private set; }
		
		
		LifetimeScopeReference(Type type)
		{
			Type = type;
			_typeName = type.FullName;
		}
		
		
		// Type에 들어갈 값에 제한(LifetimeScope 상속)을 걸기 위해
		// 객체가 제네릭 메서드를 거쳐서만 생성되도록 함
		public static LifetimeScopeReference Create<T>() where T : LifetimeScope
		{
			return new LifetimeScopeReference(typeof(T));
		}
		
		
		
		public bool IsValid()
		{
			return Type != null;
		}
		
		public void OnBeforeSerialize()
		{
		}

		// 역직렬화되면 TypeName을 기반으로 Type을 찾아서 할당
		public void OnAfterDeserialize()
		{
			Type = null;
			
			if (string.IsNullOrEmpty(_typeName))
			{
				return;
			}
			
			foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				Type = assembly.GetType(_typeName); // type의 FullName을 바탕으로 Type을 찾음
				if (Type != null)
				{
					Debug.Log(Type.FullName);
					break;
				}
			}
			
			if (Type == null)
			{
				_typeName = null;
			}
		}
	}

}