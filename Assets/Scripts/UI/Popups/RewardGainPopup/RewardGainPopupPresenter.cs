using System.Collections;
using System.Collections.Generic;
using ProjectB.Data.Types;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Popups.RewardGainPopup
{

	public class RewardGainPopupPresenter : UIPresenter<RewardGainPopupView>
	{
		[SerializeField] private float _addItemCardLoopDelay = 0.1f; // 팝업이 열리면 아이템 카드가 빠르게 뜸 (촤라락)

		private WaitForSecondsRealtime _addItemCardLoopDelayYieldCache;
		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.BackgroundClickAreaClicked += OnBackgroundClickAreaClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.BackgroundClickAreaClicked -= OnBackgroundClickAreaClicked;
		}
		
		// 아무 곳(배경)이나 누르면 화면을 닫음 
		void OnBackgroundClickAreaClicked()
		{
			Hide();
		}

		public void OpenPopup(IEnumerable<ItemGain> itemGains)
		{
			view.ClearItemCards();
			Show();
			view.PlayPopupAnimation();
			StartCoroutine(AddItemCardLoop(itemGains));
		}

		IEnumerator AddItemCardLoop(IEnumerable<ItemGain> itemGains)
		{
			if (_addItemCardLoopDelayYieldCache == null)
			{
				_addItemCardLoopDelayYieldCache = new WaitForSecondsRealtime(_addItemCardLoopDelay);
			}
			
			foreach (var itemGain in itemGains)
			{
				view.AddItemCard(itemGain.item, itemGain.quantity);
				yield return _addItemCardLoopDelayYieldCache;
			}
		}
	}

}