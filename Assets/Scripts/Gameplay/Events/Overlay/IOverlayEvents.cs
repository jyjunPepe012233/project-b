using System;

namespace ProjectB.Gameplay.Events.Overlay
{

	public interface IOverlayEvents
	{
		// Overlay가 열릴 때 발생
		Action Open { get; set; }
		
		// Overlay가 닫힐 때 발생
		Action Close { get; set; }
		
		// Overlay가 스택에서 밀려났다가 화면에서 보여질 때 발생
		Action Show { get; set; }
		
		// Overlay가 스택에서 밀려나서 화면에서 사라질 때 발생
		Action Hide { get; set; }
	}

}