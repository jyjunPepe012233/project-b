using System.Collections;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.UI.Services;
using UnityEngine;

namespace ProjectB.Infrastructure
{

	public abstract class BaseHomeOverlayScreenService
	{
		private HomeOverlaysControlService _uiService;
		// 근데 HomeOverlaysControlService도 DI로 주입받을 수는 없나?
		//   26. 05. 23. HomeOverlaysControlService는 외부 기술(UI 시스템)의 일부이기 때문에 DI에 참여시키면 안 됨.

		public HomeOverlaysControlService UIService
		{
			get
			{
				if (_uiService == null)
				{
					_uiService = Object.FindObjectOfType<HomeOverlaysControlService>();

					if (_uiService == null)
					{
						Debug.LogError("현재 Home 씬이 아닙니다. BaseHomeOverlayScreenService는 Home 씬에서만 사용할 수 있습니다.");
						return null;
					}
				}

				return _uiService;
			}
		}

		public bool IsLoaded => UIService.CurrentOverlayID == OverlayID;

		// 이 프로퍼티를 상속받아 override하여 특정 ID("Backpack, "Summon" 등)의 오버레이를 제어하도록 구현할 수 있음
		protected abstract string OverlayID { get; }



		public IEnumerator Load()
		{
			if (UIService != null)
			{
				UIService.OpenOverlay(OverlayID);
				yield return null; // 한 프레임을 쉬어서 완벽히 활성화된 상태로 만듬
			}
		}

		public IEnumerator Unload()
		{
			if (UIService != null)
			{
				if (UIService.CurrentOverlayID == OverlayID)
				{
					UIService.CloseOverlay();
					yield return null; // 한 프레임을 쉬어서 완벽히 비활성화된 상태로 만듬
				}
				else
				{
					Debug.LogError($"현재 Overlay가 {OverlayID} 아닙니다. 현재 Overlay: {UIService.CurrentOverlayID}");
				}
			}
		}
	}

}