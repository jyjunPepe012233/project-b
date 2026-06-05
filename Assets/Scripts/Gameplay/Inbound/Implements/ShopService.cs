using ProjectB.Data.Static.Shop;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Inbound.Ports;
using ProjectB.Gameplay.Internal.Ports;
using ProjectB.Gameplay.Outbound.Ports.Player;
using UnityEngine;

namespace ProjectB.Gameplay.Inbound.Implements
{

	public class ShopService : IShopService
	{
		private readonly IHoldPlayerSessionPort _holdPlayerSessionPort;
		private readonly IInternalInventoryService _internalInventoryService;

		public ShopService(IHoldPlayerSessionPort holdPlayerSessionPort, IInternalInventoryService internalInventoryService)
		{
			_holdPlayerSessionPort = holdPlayerSessionPort;
			_internalInventoryService = internalInventoryService;
		}

		public void BuyItem(IShopItem shopItem)
		{
			if (shopItem == null || shopItem.ItemData == null)
			{
				Debug.LogError("매개변수에 null이 전달되었음. 확인 바람");
				return;
			}

			if (shopItem.Price < 0)
			{
				Debug.LogError($"shopItem.Price가 0보다 작음. 확인 바람 shopItem.ItemData: {shopItem.ItemData}, shopItem.Price: {shopItem.Price}");
				return;
			}
			
			var playerData = _holdPlayerSessionPort.GetPlayerSession().PlayerData;

			// switch문에서 각 재화 소모 시도 후
			// 재화 소모에 성공하면 성공 플래그(isPurchaseSuccess)를 true로 바꿈
			bool isPurchaseSuccess = false;
			switch (shopItem.CurrencyType)
			{
				case CurrencyType.Coins:
					if (playerData.TryConsumeCoins(shopItem.Price))
						isPurchaseSuccess = true;
					break;
				case CurrencyType.Gems:
					if (playerData.TryConsumeGems(shopItem.Price))
						isPurchaseSuccess = true;
					break;
			}

			if (isPurchaseSuccess)
			{
				_internalInventoryService.GiveItem(shopItem.ItemData, shopItem.Quantity, ItemGainAction.Reward);
			}
		}
	}

}