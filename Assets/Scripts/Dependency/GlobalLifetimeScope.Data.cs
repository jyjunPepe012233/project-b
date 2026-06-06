using ProjectB.Data.Static.Invasion;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Static.Morale;
using ProjectB.Data.Static.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Static.Summon;
using ProjectB.Infrastructure.Authoring.Invasion;
using ProjectB.Infrastructure.Authoring.Item;
using ProjectB.Infrastructure.Authoring.Morale;
using ProjectB.Infrastructure.Authoring.Player;
using ProjectB.Infrastructure.Authoring.Soldier;
using ProjectB.Infrastructure.Authoring.Summon;
using UnityEngine;

namespace ProjectB.Dependency
{

	public partial class GlobalLifetimeScope
	{
		[Header("Authoring Data")]
		[SerializeField] private SoldierDatabaseSO _soldierDatabaseSO;
		[SerializeField] private ItemDatabaseSO _itemDatabaseSO;
		[SerializeField] private InvasionSettingSO _invasionSettingSO;
		[SerializeField] private SummonCostSettingSO _summonCostSettingSo;
		[SerializeField] private MoraleSettingSO _moraleSettingSO;
		[SerializeField] private SweepSettingSO _sweepSettingSO;
		[SerializeField] private PlayerLevelUpSettingSO _playerLevelUpSettingSO;
		[SerializeField] private GlobalSoldierLevelUpSettingSO _globalSoldierLevelUpSettingSO;
		
		void RegisterData()
		{
			RegisterPortInstance<IInvasionSetting, InvasionSettingSO>(_invasionSettingSO);
			RegisterPortInstance<ISoldierDatabase, SoldierDatabaseSO>(_soldierDatabaseSO);
			RegisterPortInstance<IItemDatabase, ItemDatabaseSO>(_itemDatabaseSO);
			RegisterPortInstance<ISummonCostSetting, SummonCostSettingSO>(_summonCostSettingSo);
			RegisterPortInstance<IMoraleSetting, MoraleSettingSO>(_moraleSettingSO);
			RegisterPortInstance<ISweepSetting, SweepSettingSO>(_sweepSettingSO);
			RegisterPortInstance<IPlayerLevelUpSetting, PlayerLevelUpSettingSO>(_playerLevelUpSettingSO);
			RegisterPortInstance<IGlobalSoldierLevelUpSetting, GlobalSoldierLevelUpSettingSO>(_globalSoldierLevelUpSettingSO);
		}
	}

}