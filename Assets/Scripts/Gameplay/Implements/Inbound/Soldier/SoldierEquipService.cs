using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Inbound.Soldier;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound.Player;
using UnityEngine;

namespace ProjectB.Gameplay.Implements.Inbound.Soldier
{

	public class SoldierEquipService : ISoldierEquipService
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		private readonly IInternalInventoryService _internalInventoryService;

		public SoldierEquipService(IPlayerSessionHolderPort playerSessionHolderPort,
			IInternalInventoryService internalInventoryService)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
			_internalInventoryService = internalInventoryService;
		}

		public void Equip(IPlayerSoldier playerSoldier, SoldierEquipmentSlot slot, IEquipmentItem equipment)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			// IEquipmentItem은 IItemData도 구현하므로 캐스팅 가능
			IItemData equipmentItemData = (IItemData)equipment;

			// playerData.Items에 없으면 null 반환 
			var existingItem = playerData.Items.FirstOrDefault(x => x.ItemData == equipmentItemData);

			// 장비를 1개만 소모하기 때문에 quantity < 1인 경우 장착 불가
			if (existingItem == null || existingItem.Quantity < 1)
			{
				Debug.LogError("보유하지 않은 장비 아이템을 장착하려고 시도했습니다!");
				return;
			}

			// 내부적으로 장비 아이템 소비를 데이터에 반영하는 데에 실패하면 장착 안 함
			if (!_internalInventoryService.TryClearItem(equipmentItemData, 1))
			{
				Debug.LogError("장비 아이템 소비에 실패했습니다!");
				return;
			}
			
			// TODO: 장비에 따라 플레이어 능력치를 업데이트하는 로직 필요
			// 전투력 계산 로직처럼 internal service의 도움을 받을 듯

			playerSoldier.SetEquipment(slot, equipment);

			// TODO: 플레이어 데이터 직렬화(JSON 저장 등) 로직 필요
		}
	}

}