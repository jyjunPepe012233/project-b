using ProjectB.Core.Types;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Static.Spirit;
using ProjectB.Data.Types;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectB.Infrastructure.Authoring.Soldier
{

	[CreateAssetMenu(menuName = "Project B/Soldier/Soldier")]
	public class SoldierSO : UnityEngine.ScriptableObject, ISoldierData, ISoldierCardDisplaySetting
	{
		public ISoldierCardDisplaySetting CardDisplaySetting => this;
		
		public ISoldierLevelUpSetting LevelUpSetting => _soldierLevelUpSettingSo;
		
		
		[Header("Soldier Info")]
		[SerializeField] private string _soldierId;
		public string SoldierId => _soldierId;
		
		[SerializeField] private string _soldierName;
		public string SoldierName => _soldierName;

		[SerializeField] private byte _bornRank = 1;
		public byte BornRank => _bornRank;

		[SerializeField] private InterfaceRef<ISpiritData> _spirit;
		public ISpiritData Spirit => _spirit.Value;
		
		[SerializeField] private InterfaceRef<ISoldierRoleData> _role;
		public ISoldierRoleData Role => _role.Value;
		
		[SerializeField] private InterfaceRef<ISoldierAttackType> _attackType;
		public ISoldierAttackType AttackType => _attackType.Value;
		
		[SerializeField] private InterfaceRef<ISoldierPosition> _position;
		public ISoldierPosition Position => _position.Value;

		[SerializeField] private SoldierStatus _baseStatus = new SoldierStatus
		{
			hp = 1000,
			sp = 300,
			physicalAttack = 150,
			magicalAttack = 150,
			physicalDefense = 150,
			magicalDefense = 150
		};
		public SoldierStatus BaseStatus => _baseStatus;
		
		[SerializeField] private SoldierStatusf _statusGrowth = new SoldierStatusf
		{
			hp = 0.1f,
			sp = 0f,
			physicalAttack = 0.1f,
			magicalAttack = 0.1f,
			physicalDefense = 0.1f,
			magicalDefense = 0.1f
		};
		public SoldierStatusf StatusGrowth => _statusGrowth;


		[Header("Card Display Setting")]
		[SerializeField] private GameObject _displayedSoldierPrefab;
		public GameObject DisplayedSoldierPrefab => _displayedSoldierPrefab;



		[FormerlySerializedAs("_soldierLevelUpExpSettingSo")]
		[Header("LevelUp Exp Setting")]
		[SerializeField] private SoldierLevelUpSettingSo _soldierLevelUpSettingSo;
	}

}
