using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound.Player;
using UnityEngine;

namespace ProjectB.Gameplay.Implements.Internal
{

	public class GainCurrencyItemResolver : IConsumableItemResolver<IGainCurrencyItem>
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;

		public GainCurrencyItemResolver(IPlayerSessionHolderPort playerSessionHolderPort)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
		}

		public void OnConsume(IGainCurrencyItem gainCurrencyItem, int count)
		{
			IPlayerData playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;
			int amount = gainCurrencyItem.Amount * count;
			
			switch (gainCurrencyItem.CurrencyType)
			{
				case CurrencyType.Coins:
					playerData.AddCoins(amount);
					break;
				
				case CurrencyType.Gems:
					playerData.AddGems(amount);
					break;
				
				default:
					Debug.LogError("GainCurrencyItem을 소모할 수 없음. 이 재화 타입에 대한 분기문이 존재하지 않음 CurrencyType: " + gainCurrencyItem.CurrencyType);
					break;
			}
		}
	}

} 