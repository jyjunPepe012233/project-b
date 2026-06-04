using System.Collections;
using ProjectB.Gameplay.Events.Overlay;

namespace ProjectB.Gameplay.Implements.Internal.Overlay
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
	}

}