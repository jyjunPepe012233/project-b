using System;
using System.Collections.Generic;
using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Views.Buttons
{

	[Serializable]
	public class ButtonView : UIView
	{
		[Required, SerializeField] private Button _button;
	
		public event Action ButtonClicked;
		
		private readonly List<Action> _registeredActions = new();

		protected override void OnSetupUICallbacks()
		{
			base.OnSetupUICallbacks();
			_button.onClick.RemoveListener(OnButtonClicked); // 중복 등록된 구독들을 모두 해제함
			_button.onClick.AddListener(OnButtonClicked);
		}

		protected override void OnDisposeUICallbacks()
		{
			base.OnDisposeUICallbacks();
			_button.onClick.RemoveListener(OnButtonClicked);
		}

		private void OnButtonClicked()
		{
			ButtonClicked?.Invoke();
		}

		public void RegisterAction(Action action)
		{
			ButtonClicked += action;
			_registeredActions.Add(action);
		}
		
		public void RemoveRegisteredAction(Action action)
		{
			// 없는 액션을 제거하는 경우에 발생하는 예외도 처리함
			try
			{
				ButtonClicked -= action;
				_registeredActions.Remove(action);
			}
			catch (Exception e)
			{
				Debug.LogWarning($"액션 제거 중 예외 발생: {e.Message}");
			}
		}
		
		public void ClearAllRegisteredActions()
		{
			foreach (var action in _registeredActions)
			{
				ButtonClicked -= action;
			}
			_registeredActions.Clear();
		}


		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("Button 할당", () => _button != null);
		}
	}
}
