using System;
using System.Collections.Generic;
using VContainer;
using VContainer.Unity;

namespace ProjectB.Dependency
{

	public sealed partial class GlobalLifetimeScope : LifetimeScope
	{
		private IContainerBuilder _builder;
		
		// 이 리스트에 등록된 타입들은 의존성 그래프가 Configure 및 Build된 이후에 Resolve(객체 생성)됨
		// Lazy Initialization 방식이 아니라 시작 **즉시 객체를 생성해야하는 타입들은 이 리스트에 등록**
		private readonly List<Type> _reservedToResolve = new List<Type>();
		
		
		void RegisterPortAdapter<TPort, TAdapter>()
			where TPort : class
			where TAdapter : class, TPort
		{
			_builder.Register<TAdapter>(Lifetime.Singleton).As<TPort>();
		}
		
		
		void RegisterPortInstance<TPort, TAdapter>(TAdapter instance)
			where TPort : class
			where TAdapter : class, TPort
		{
			_builder.RegisterInstance(instance).As<TPort>();
		}


		void RegisterMonoSystem<T>() where T : class
		{
			_builder.Register<T>(Lifetime.Singleton);
			
			// Mono System은 Initializer이거나 Event Listener인 경우가 많으므로
			// Lazy Initialization 대신 즉시 생성 방식 사용
			
//			Container.Resolve<T>(); // 이 시점에서는 Container가 할당되지 않아 Resolve 불가능. 대신 리스트에 저장하기
			_reservedToResolve.Add(typeof(T));
		}
		
		

		protected override void Configure(IContainerBuilder builder)
		{
			_builder = builder;
			
			RegisterData();
			RegisterInboundSystems();
			RegisterInternalSystems();
			RegisterOutboundSystems();
		}

		protected override void Awake()
		{
			base.Awake(); // 이 시점에 의존성 그래프 Configure와 Build 과정이 진행됨

			foreach (var type in _reservedToResolve)
			{
				// 게임 시작 시 객체 생성이 필요한 타입들은 여기서 생성
				Container.Resolve(type);
			}
		} 
	}

}
