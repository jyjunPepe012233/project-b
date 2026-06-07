using ProjectB.Data.Static.Soldier;
using UnityEngine;

namespace ProjectB.Authoring.Soldier
{

	[CreateAssetMenu(menuName = "Project B/Soldier/Attack Type")]
	public class SoldierAttackTypeSO : UnityEngine.ScriptableObject, ISoldierAttackType
	{
		[SerializeField] private string _soldierAttackTypeName;
		public string SoldierAttackTypeName => _soldierAttackTypeName;
		
		[SerializeField] private GameObject _iconPrefab64;
		public GameObject IconPrefab64 => _iconPrefab64;
	}

}