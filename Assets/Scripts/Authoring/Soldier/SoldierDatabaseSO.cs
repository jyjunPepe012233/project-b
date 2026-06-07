using System.Collections.Generic;
using System.Linq;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Soldier;
using UnityEngine;

namespace ProjectB.Authoring.Soldier
{

	[CreateAssetMenu(menuName = "Project B/Soldier/Soldier Database")]
	public class SoldierDatabaseSO : UnityEngine.ScriptableObject, ISoldierDatabase
	{
		[SerializeField] private InterfaceRefs<ISoldierData> _soldiers;
		public IReadOnlyList<ISoldierData> Soldiers => _soldiers.Value;

		private readonly Dictionary<string, ISoldierData> _idToDataTable = new();
		
		public ISoldierData GetSoldierById(string soldierId)
		{
			if (_idToDataTable.TryGetValue(soldierId, out var cached))
			{
				return cached;
			}

			var found = _soldiers.Value.FirstOrDefault(soldier => soldier.SoldierId == soldierId);
			_idToDataTable.Add(soldierId, found);
			
			return found;
		}

		public bool VerifySoldierId(string soldierId)
		{
			return GetSoldierById(soldierId) != null;
		}
	}

}
