using System;
using ProjectB.Data.Static.Morale;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay
{

	public class RechargeMoraleService : IRechargeMoraleServicePort
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		private readonly IMoraleSetting _moraleSetting;

		public RechargeMoraleService(IPlayerSessionHolderPort playerSessionHolderPort, IMoraleSetting moraleSetting)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
			_moraleSetting = moraleSetting;
		}

		public int GetRemainingRechargeCount()
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;
			return _moraleSetting.MaxDailyRechargeCount - playerData.DailyMoraleRechargeCount;
		}
		
		public int GetExpectedMoraleAfterRecharge(int count)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;
			return Math.Min(playerData.Morale + count * _moraleSetting.MoralePerRecharge, _moraleSetting.MaxMorale);
		}
		
		public int GetRechargeCost(int count)
		{
			return _moraleSetting.RechargePrice * count;
		}

		public bool VerifyRechargeCount(int count)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;
			
			// 일일 충전 횟수가 초과되면 충전 불가
			if (playerData.DailyMoraleRechargeCount + count > _moraleSetting.MaxDailyRechargeCount)
			{
				return false;
			}
			
			// 충전으로 인해 사기가 최대치를 충전하는 경우에는 충전 불가
			int rechargeAmount = _moraleSetting.MoralePerRecharge * count;
			if (playerData.Morale + rechargeAmount > _moraleSetting.MaxMorale)
			{
				return false;
			}
			
			return true;
		}

		public void Recharge(int count)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			if (!VerifyRechargeCount(count))
			{
				return;
			}

			if (!playerData.TryConsumeGems(_moraleSetting.RechargePrice * count))
			{
				return;
			}
			
			playerData.AddDailyMoraleRechargeCount(count);
			playerData.AddMorale(count * _moraleSetting.MoralePerRecharge);
		}
	}

}
