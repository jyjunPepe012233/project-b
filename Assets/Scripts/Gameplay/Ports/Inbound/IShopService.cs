using ProjectB.Data.Static.Shop;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IShopService
	{
		void BuyItem(IShopItem shopItem);
	}

}