using System.Collections.Generic;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.UI.Popups.RewardGainPopup;
using UnityEngine;

namespace ProjectB.UI.Services
{

	public class RewardGainPopupService : MonoBehaviour
	{
		[SerializeField] private RewardGainPopupComponent _rewardGainPopupComponent;

		public bool Opening
		{
			get
			{
				Debug.LogError("현재 IsOpening 프로퍼티는 미구현되었음. false를 반환함");
				return false;
			}
		}

		public void OpenPopup(IEnumerable<ItemGain> itemGains)
		{
			_rewardGainPopupComponent.OpenPopup(itemGains);
		}
	}

}