using System;
using System.Collections;
using ProjectB.Gameplay.Events.Overlay;
using ProjectB.Gameplay.Internal.Ports.Overlay;

namespace ProjectB.Gameplay.Internal.Implements.Overlay
{

	public abstract class EventBasedOverlayController<TEvents> : IOverlayController where TEvents : IOverlayEvents
	{
		private readonly TEvents _events;
		
		protected EventBasedOverlayController(TEvents events)
		{
			_events = events;
		}
		
		public virtual IEnumerator Open()
		{
			_events.Open?.Invoke();
			yield return null; // UI 조작 후 안정성을 위해 한 프레임 대기
		}
		
		public virtual IEnumerator Close()
		{
			_events.Close?.Invoke();
			yield return null; // UI 조작 후 안정성을 위해 한 프레임 대기
		}

		public IEnumerator Show()
		{
			_events.Show?.Invoke();
			yield return null; // UI 조작 후 안정성을 위해 한 프레임 대기
		}

		public IEnumerator Hide()
		{
			_events.Hide?.Invoke();
			yield return null; // UI 조작 후 안정성을 위해 한 프레임 대기
		}
	}

}