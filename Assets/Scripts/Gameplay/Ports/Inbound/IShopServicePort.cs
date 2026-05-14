using ProjectB.Data.Static.Shop;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IShopServicePort
	{
		void BuyItem(IShopItem shopItem);
	}

}