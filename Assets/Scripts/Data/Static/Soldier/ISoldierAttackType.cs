using UnityEngine;

namespace ProjectB.Data.Static.Soldier
{

	public interface ISoldierAttackType
	{
		string SoldierAttackTypeName { get; }
		
		GameObject IconPrefab64 { get; }
	}

}