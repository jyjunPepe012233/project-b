using System;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Buttons.Common
{

	[Serializable]
	public class ButtonView : UIView
	{
		[SerializeField]
		private Button _button;
	
		public event Action ButtonClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
		
			if (_button == null)
			{
				Debug.LogError($"[{nameof(ButtonView)}] Button 컴포넌트가 할당되지 않았습니다.");
				return;
			}
		
			_button.onClick.AddListener(OnButtonClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
		
			if (_button == null)
				return;
		
			_button.onClick.RemoveListener(OnButtonClicked);
		}
	
		private void OnButtonClicked()
		{
			ButtonClicked?.Invoke();
		}
	}

	
	// TODO: 다음 할 일 메모 26.05.11. 오후 6시
	// 지금 UI 안 만들고 계속 Service 쪽 스크립팅만 하는 중임.
	// 플레이어 정보 시스템 만들고 있고, 레벨과 Experience 시스템을 다 만듬.
	// 지금은 플레이어 레벨에 따라 Soldier의 레벨이 제한되는 시스템 만들고 있음. 이거 다 만들고 나서 플레이어 레벨 등 플레이어 정보 종합하는 API 만들면 될 듯.
	// 그렇게 해서 플레이어 정보 다 만들어지면 더 만들 기능은 없음 UI 다 만들고 Addressable 기반 리소스 관리 시스템 만들면 됨.
}
