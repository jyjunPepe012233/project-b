namespace ProjectB.Gameplay.Inbound.Ports.Overlay
{

	public interface IOverlayStackService
	{
		void CloseCurrentOverlay();
		
		void CloseAllOverlays();
	}

}