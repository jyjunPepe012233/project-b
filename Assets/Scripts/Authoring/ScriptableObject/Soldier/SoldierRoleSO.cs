using ProjectB.Data.Static.Soldier;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Soldier
{

	[CreateAssetMenu(menuName = "Project B/Soldier/Role")]
	public class SoldierRoleSO : UnityEngine.ScriptableObject, ISoldierRoleData
	{
		[SerializeField] private string _soldierRoleName;
		public string SoldierRoleName => _soldierRoleName;
		
		[SerializeField] private GameObject _iconPrefab64;
		public GameObject IconPrefab64 => _iconPrefab64;
	}

}
