using System.Collections;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.UI.Services;
using UnityEngine;

namespace ProjectB.Infrastructure
{

	public class LoadBackpackScreenService : ILoadBackpackScreenPort
	{
		private HomeOverlaysControlService _homeOverlaysControlService;
		// 근데 HomeOverlaysControlService도 DI로 주입받을 수는 없나?
		//   26. 05. 23. HomeOverlaysControlService는 외부 기술(UI 시스템)의 일부이기 때문에 DI에 참여시키면 안 됨.

		public bool IsLoaded => GetUIService(out var service) && service.CurrentOverlayID == "Backpack";

		public IEnumerator Load()
		{
			if (GetUIService(out var service))
			{
				service.OpenOverlay("Backpack");
				yield return null; // 한 프레임을 쉬어서 완벽히 활성화된 상태로 만듬
			}
		}

		public IEnumerator Unload()
		{
			if (GetUIService(out var service))
			{
				service.CloseOverlay();
				yield return null;
			}
		}
		
		bool GetUIService(out HomeOverlaysControlService service)
		{
			if (_homeOverlaysControlService != null)
			{
				service = _homeOverlaysControlService;
				return true;
			}
			
			var uiService = Object.FindObjectsOfType<HomeOverlaysControlService>();
			if (uiService.Length > 0)
			{
				_homeOverlaysControlService = uiService[0];
				service = uiService[0];
				return true;
			}
			else
			{
				Debug.LogError("현재 Home 씬이 아닙니다. LoadBackpackScreenService는 Home 씬에서만 사용할 수 있습니다.");
				service = null;
				return false;
			}
		}
	}

}