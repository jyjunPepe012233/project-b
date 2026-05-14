using UnityEngine;

namespace ProjectB.Data.Static.Soldier
{

	public interface ISoldierRoleData
	{
		string SoldierRoleName { get; }
		
		GameObject IconPrefab64 { get; }
	}

}