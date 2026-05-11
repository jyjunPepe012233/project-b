using System;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Data.RuntimeImpl
{

	public class PlayerSoldier : IPlayerSoldier
	{
		public string SoldierId { get; }
		
		public byte Rank { get; private set; }
		
		public int Exp { get; private set; }

		public short Level { get; private set; }
		
		public SoldierStatus Status { get; private set; }
		
		public SoldierEquipments Equipments { get; private set; }
		
		public int CombatPower { get; private set; }

		public event Action RankChanged;
		public event Action ExpChanged;
		public event Action LevelChanged;
		public event Action StatusChanged;
		public event Action EquipmentsChanged;
		public event Action CombatPowerChanged;


		public PlayerSoldier(ISoldierData soldierData,
			byte rank,
			int exp,
			short level,
			SoldierStatus status,
			int combatPower)
		{
			SoldierId = soldierData.SoldierId;
			Rank = rank;
			Exp = exp;
			Level = level;
			Status = status;
			CombatPower = combatPower;
		}

		public void SetRank(byte rank)
		{
			Rank = rank;
			RankChanged?.Invoke();
		}

		public void SetExp(int exp)
		{
			Exp = exp;
			ExpChanged?.Invoke();
		}

		public void SetLevel(short level)
		{
			Level = level;
			LevelChanged?.Invoke();
		}

		public void SetStatus(SoldierStatus status)
		{
			Status = status;
			StatusChanged?.Invoke();
		}
		
		public void SetEquipment(SoldierEquipmentSlot slot, IEquipmentItem equipment)
		{
			var equipmentsTemp = Equipments; // struct 복사본 생성
			
			switch (slot)
			{
				case SoldierEquipmentSlot.Slot1: equipmentsTemp.slot1 = equipment; break;
				case SoldierEquipmentSlot.Slot2: equipmentsTemp.slot2 = equipment; break;
				case SoldierEquipmentSlot.Slot3: equipmentsTemp.slot3 = equipment; break;
				case SoldierEquipmentSlot.Slot4: equipmentsTemp.slot4 = equipment; break;
				case SoldierEquipmentSlot.Slot5: equipmentsTemp.slot5 = equipment; break;
				case SoldierEquipmentSlot.Slot6: equipmentsTemp.slot6 = equipment; break;
			}

			Equipments = equipmentsTemp; // struct를 교체
			EquipmentsChanged?.Invoke();
		}

		public void ClearEquipment(SoldierEquipmentSlot slot)
		{
			var equipmentsTemp = Equipments; // struct 복사본 생성
			
			switch (slot)
			{
				case SoldierEquipmentSlot.Slot1: equipmentsTemp.slot1 = null; break;
				case SoldierEquipmentSlot.Slot2: equipmentsTemp.slot2 = null; break;
				case SoldierEquipmentSlot.Slot3: equipmentsTemp.slot3 = null; break;
				case SoldierEquipmentSlot.Slot4: equipmentsTemp.slot4 = null; break;
				case SoldierEquipmentSlot.Slot5: equipmentsTemp.slot5 = null; break;
				case SoldierEquipmentSlot.Slot6: equipmentsTemp.slot6 = null; break;
			}

			Equipments = equipmentsTemp; // struct를 교체
			EquipmentsChanged?.Invoke();
		}
		
		public void SetCombatPower(int combatPower)
		{
			CombatPower = combatPower;
			CombatPowerChanged?.Invoke();
		}
	}

}