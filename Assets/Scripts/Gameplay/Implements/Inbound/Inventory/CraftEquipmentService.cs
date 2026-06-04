using System.Linq;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Inbound.Inventory;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound.Player;
using UnityEngine;

namespace ProjectB.Gameplay.Implements.Inbound.Inventory
{

	public class CraftEquipmentService : ICraftEquipmentService
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		private readonly IInternalInventoryService _internalInventoryService;

		public CraftEquipmentService(IPlayerSessionHolderPort playerSessionHolderPort,
			IInternalInventoryService internalInventoryService)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
			_internalInventoryService = internalInventoryService;
		}

		public void Craft(IEquipmentItem equipment)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;
			var craftMaterials = equipment.CraftMaterials.ToArray();

			// 재료 전체 사전 검증
			foreach (var craftMaterial in craftMaterials)
			{
				var existingItem = playerData.Items.FirstOrDefault(x => x.ItemData == craftMaterial.material);

				if (existingItem == null || existingItem.Quantity < craftMaterial.amount)
				{
					Debug.LogError($"제작 재료가 부족합니다! 재료: {craftMaterial.material.ItemId}, 필요: {craftMaterial.amount}");
					return;
				}
			}

			// 재료 일괄 소모
			foreach (var craftMaterial in craftMaterials)
			{
				_internalInventoryService.TryClearItem(craftMaterial.material, craftMaterial.amount);
			}

			// IEquipmentItem은 IItemData도 구현하므로 캐스팅하여 인벤토리에 지급
			_internalInventoryService.GiveItem(equipment, 1, ItemGainAction.Reward);

			// TODO: 플레이어 데이터 직렬화(JSON 저장 등) 로직 필요
		}
	}

}
