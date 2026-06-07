using ProjectB.Data.Static.Soldier;
using UnityEngine;

namespace ProjectB.Authoring.Soldier
{

	[CreateAssetMenu(menuName = "Project B/Soldier/Position")]
	public class SoldierPositionSO : UnityEngine.ScriptableObject, ISoldierPosition
	{
		[SerializeField] private string _soldierPositionName;
		public string SoldierPositionName => _soldierPositionName;
		
		[SerializeField] private GameObject _iconPrefab64;
		public GameObject IconPrefab64 => _iconPrefab64;
		
		[SerializeField] private bool _canFront;
		public bool CanFront => _canFront;
		
		[SerializeField] private bool _canMid;
		public bool CanMid => _canMid;
		
		[SerializeField] private bool _canBack;
		public bool CanBack => _canBack;
	}

}