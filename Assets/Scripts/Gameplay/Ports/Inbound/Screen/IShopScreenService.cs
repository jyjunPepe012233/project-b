namespace ProjectB.Gameplay.Ports.Inbound.Screen
{

	public interface IShopScreenService : IBaseScreenService
	{
		void Open();

		void Close();
	}

}