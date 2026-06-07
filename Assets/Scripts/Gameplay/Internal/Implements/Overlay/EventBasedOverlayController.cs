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
			yield break;
		}
		
		public virtual IEnumerator Close()
		{
			_events.Close?.Invoke();
			yield break;
		}

		public IEnumerator Show()
		{
			_events.Show?.Invoke();
			yield break;
		}

		public IEnumerator Hide()
		{
			_events.Hide?.Invoke();
			yield break;
		}
	}

}