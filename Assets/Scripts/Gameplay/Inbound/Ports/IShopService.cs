using ProjectB.Data.Static.Shop;

namespace ProjectB.Gameplay.Inbound.Ports
{

	public interface IShopService
	{
		void BuyItem(IShopItem shopItem);
	}

}