using System.Collections;
using System.Collections.Generic;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.UI.Services;
using UnityEngine;

namespace ProjectB.Infrastructure
{

	public class LoadRewardGainPopupPort : ILoadRewardGainPopupPort
	{
		private RewardGainPopupService _rewardGainPopupService;

		public bool IsLoaded => GetUIService(out var service) && service.Opening;
		
		public IEnumerator Load(IEnumerable<ItemGain> itemGains)
		{
			
			if (GetUIService(out var service))
			{
				service.OpenPopup(itemGains);
			}

			// 루틴이 즉시 종료되도록 구현됨. 필요에 따라 변경 가능
			yield break;
		}
		
		bool GetUIService(out RewardGainPopupService service)
		{
			if (_rewardGainPopupService != null)
			{
				service = _rewardGainPopupService;
				return true;
			}
			
			var uiService = Object.FindObjectsOfType<RewardGainPopupService>();
			if (uiService.Length > 0)
			{
				_rewardGainPopupService = uiService[0];
				service = uiService[0];
				return true;
			}
			else
			{
				Debug.LogError("LoadRewardGainPopupPort를 찾을 수 없습니다");
				service = null;
				return false;
			}
		} 
	}

}