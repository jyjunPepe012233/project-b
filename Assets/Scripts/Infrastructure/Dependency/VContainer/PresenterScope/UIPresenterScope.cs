using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.Infrastructure.Dependency.VContainer.PresenterScope
{

	public abstract class UIPresenterScope<TPresenter> : LifetimeScopeInjectionTarget, IValidatable
		where TPresenter : UIPresenter
	{
		protected TPresenter Presenter { get; private set; }

		
		[SerializeField, Readonly] private bool _isInitialized; 
		public bool IsInitialized => _isInitialized;
		
		protected override void OnInjected()
		{
			base.OnInjected();
			Presenter = Compose();
			
			_isInitialized = true;
			Presenter.Initialize();
		}

		protected virtual void OnEnable()
		{
			if (IsInjected && !IsInitialized)
			{
				_isInitialized = true;
				Presenter.Initialize();
			}
		}

		protected virtual void OnDisable()
		{
			if (IsInitialized)
			{
				Presenter.Dispose();
				_isInitialized = false;
			}
		}
		
		protected virtual void OnDestroy()
		{
			if (IsInitialized)
			{
				Presenter.Dispose();
				_isInitialized = false;
			}
		}

		protected abstract TPresenter Compose();

		
		
		MonoBehaviour IValidatable.GetMonoBehaviour() => this;

		public ValidationMethod GetValidationMethod()
		{
			return new ValidationMethod()
				.Register("LifetimeScope Reference 설정", _reference.IsValid);
		}
	}

}