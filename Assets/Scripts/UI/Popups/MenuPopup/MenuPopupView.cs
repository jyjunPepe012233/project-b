using System;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Popups.MenuPopup
{

	[Serializable]
	public class MenuPopupView : UIView
	{
		[SerializeField] private Button _closeButton;
		[SerializeField] private Button _openBackpackButton;
		
		public event Action CloseButtonClicked;
		public event Action OpenBackpackButtonClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_closeButton.onClick.AddListener(OnCloseButtonClicked);
			_openBackpackButton.onClick.AddListener(OnOpenBackpackButtonClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
			_closeButton.onClick.RemoveListener(OnCloseButtonClicked);
			_openBackpackButton.onClick.RemoveListener(OnOpenBackpackButtonClicked);
		}
		
		void OnCloseButtonClicked()
		{
			CloseButtonClicked?.Invoke();
		}

		void OnOpenBackpackButtonClicked()
		{
			OpenBackpackButtonClicked?.Invoke();
		}
	}

}