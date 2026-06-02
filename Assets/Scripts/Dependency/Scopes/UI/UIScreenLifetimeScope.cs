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
		
		private readonly List<UIPresenter> _presenters = new List<UIPresenter>();

		protected override void Awake()
		{
			base.Awake();
			
			if (_dontDestroyOnLoad)
			{
				DontDestroyOnLoad(gameObject);
			}
		}

		protected virtual void Start()
		{
			SetupUI();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			
			foreach (var presenter in _presenters)
			{
				presenter.Dispose();
			}
		}

		protected virtual void SetupUI()
		{
			
		}
	}

}