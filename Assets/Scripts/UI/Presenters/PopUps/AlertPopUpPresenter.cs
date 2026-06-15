using System.Collections;
using ProjectB.Core.Supports;
using ProjectB.Gameplay.Events;
using ProjectB.UI.Core;
using ProjectB.UI.Views.Common;
using ProjectB.UI.Views.Media;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace ProjectB.UI.Presenters.PopUps
{

	public class AlertPopUpPresenter : UIPresenter
	{
		private readonly TopElementView _topElementView;
		private readonly TextView _alertMessageView;
		private readonly PlayableView _playableView;
		private readonly PlayableAsset _playableAsset;
		
		private readonly AlertEvents _alertEvents;

		private readonly WaitForSeconds _hideDelayYield = new WaitForSeconds(1.5f);
		
		private Coroutine _currentAlertCoroutine;

		public AlertPopUpPresenter(TopElementView topElementView,
			TextView alertMessageView,
			PlayableView playableView,
			PlayableAsset playableAsset,
			AlertEvents alertEvents)
		{
			_topElementView = topElementView;
			_alertMessageView = alertMessageView;
			_playableView = playableView;
			_playableAsset = playableAsset;
			_alertEvents = alertEvents;
		}

		protected override void SetupModelSubscription()
		{
			base.SetupModelSubscription();
			_alertEvents.Alert += OnAlert;
		}

		protected override void DisposeModelSubscription()
		{
			base.DisposeModelSubscription();
			_alertEvents.Alert -= OnAlert;
		}

		void OnAlert(string message)
		{
			if (_currentAlertCoroutine != null)
			{
				CoroutineHandler.Stop(_currentAlertCoroutine);
			}
			
			_currentAlertCoroutine = CoroutineHandler.StartAndAdd(AlertRoutine(message));
		}

		IEnumerator AlertRoutine(string message)
		{
			_alertMessageView.SetText(message, true);

			yield return null;
			LayoutRebuilder.ForceRebuildLayoutImmediate(_alertMessageView.transform as RectTransform);
			
			// 팝업은 일반적으로 defaultDisable이므로 True로 설정
			_topElementView.Show(includeDefaultDisable: true);
			
			yield return _playableView.Play(_playableAsset);
			
			// 일정 시간동안 팝업을 보여주다가 Hide되게 함
			yield return _hideDelayYield;
			
			_topElementView.Hide();
			_currentAlertCoroutine = null;
		}
	}

}
