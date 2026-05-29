using System.Collections.Generic;
using ProjectB.UI.Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectB.Dependency.Scopes.UI
{

	public abstract class UIScreenLifetimeScope : LifetimeScope
	{
		[SerializeField] private bool _dontDestroyOnLoad;
		
		private IContainerBuilder _builder;
		
		private readonly List<UIPresenter> _presenters = new List<UIPresenter>();

		protected override void Awake()
		{
			base.Awake();
			
			if (_dontDestroyOnLoad)
			{
				DontDestroyOnLoad(gameObject);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			
			foreach (var presenter in _presenters)
			{
				presenter.Dispose();
			}
		}

		protected sealed override void Configure(IContainerBuilder builder)
		{
			base.Configure(builder);
			_builder = builder;
			
			OnRegisterViews();
			OnRegisterPresenters();
		}

		
		
		// 이 메서드에서 View를 등록해야 함
		protected abstract void OnRegisterViews();
		
		// 이 메서드에서 Presenter를 등록해야 함
		protected abstract void OnRegisterPresenters();
		
		
		
		protected void RegisterView<TView>(TView view) where TView : UIView
		{
			_builder.RegisterInstance(view);
		}

		protected void RegisterPresenter<TPresenter>() where TPresenter : UIPresenter
		{
			_builder.Register<TPresenter>(Lifetime.Scoped); // UI는 씬/오브젝트에 종속되므로 Lifetime.Scoped로 등록함
			
			TPresenter presenter = Container.Resolve<TPresenter>(); // 등록된 Presenter 인스턴스를 생성
			presenter.Initialize();
			_presenters.Add(presenter); // 등록된 Presenter 인스턴스를 생성하여 리스트에 추가
		} 
	}

}