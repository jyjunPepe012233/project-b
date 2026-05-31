namespace ProjectB.Gameplay.Ports.Inbound.Screen
{

	public interface ISummonScreenService : IBaseScreenService
	{
		void Open();
		
		void Close();
	}

}