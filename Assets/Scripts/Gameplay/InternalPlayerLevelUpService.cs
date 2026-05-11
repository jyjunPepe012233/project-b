using ProjectB.Data.Static.Player;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class InternalPlayerLevelUpService : IInternalPlayerLevelUpServicePort
	{
		private readonly IPlayerLevelUpSetting _playerLevelUpSetting;
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;

		public InternalPlayerLevelUpService(IPlayerLevelUpSetting playerLevelUpSetting, IPlayerSessionHolderPort playerSessionHolderPort)
		{
			_playerLevelUpSetting = playerLevelUpSetting;
			_playerSessionHolderPort = playerSessionHolderPort;
		}

		public void GiveExperience(int experience)
		{
			if (experience < 0)
			{
				Debug.LogError("올바르지 않은 경험치 파라미터가 전달되었습니다: " + experience);
			}
			
			
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			// 최대 레벨 확인
			if (playerData.Level == _playerLevelUpSetting.MaxLevel)
			{
				Debug.LogWarning("플레이어가 이미 최대 레벨에 도달했습니다. 경험치를 더 이상 획득할 수 없습니다.");
				return;
			}

			
			
			// 아래 while 연산에서 플레이어의 레벨이 여러 번 오를 수 있기 때문에
			// IPlayerData.AddLevel를 통해 한번에 업데이트할 수 있도록 int에 임시로 저장함
			int increasedLevel = 0;
			
			while (true)
			{
				int remainingExpToLevelUp = _playerLevelUpSetting.GetLevelUpExpOfLevel(playerData.Level + increasedLevel) - playerData.Experience;
				
				// 경험치가 레벨업에 필요한 경험치보다 적으면 경험치를 더하고 바로 종료함
				// 레벨업에 필요한 경험치와 같으면 레벨업을 하고 남은 경험치가 0이므로 다음 루프의 이 위치에서 바로 종료됨
				if (experience <= remainingExpToLevelUp)
				{
					playerData.AddExperience(experience);
					break;
				}
				
				// 경험치가 레벨업에 필요한 경험치보다 많으면 레벨업을 하고 남은 경험치로 다시 계산함
				experience -= remainingExpToLevelUp;
				increasedLevel++;
			}
			
			if (playerData.Level + increasedLevel > _playerLevelUpSetting.MaxLevel)
			{
				Debug.LogWarning("플레이어가 최대 레벨을 초과하여 레벨업하려고 시도했습니다. 레벨업이 최대 레벨까지만 적용됩니다.");
				increasedLevel = _playerLevelUpSetting.MaxLevel - playerData.Level;
			}
			
			// increasedLevel에 임시로 저장한 레벨업 횟수만큼 레벨을 올림
			playerData.AddLevel(increasedLevel);
		}
	}

}