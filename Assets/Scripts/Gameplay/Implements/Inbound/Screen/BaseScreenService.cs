using System;
using ProjectB.Gameplay.Ports.Inbound.Screen;

namespace ProjectB.Gameplay.Implements.Inbound.Screen
{

	public abstract class BaseScreenService : IBaseScreenService
	{
		public ScreenServiceEvents Events { get; } = new ScreenServiceEvents();
		
		public void Open()
		{
			Events.InvokeOpen();
		}

		public void Close()
		{
			Events.InvokeClose();
		}
	}

}