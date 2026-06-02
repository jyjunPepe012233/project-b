using ProjectB.Data.Static.Spirit;
using UnityEngine;

namespace ProjectB.Infrastructure.Authoring.Spirit
{

	[CreateAssetMenu(menuName = "Project B/Spirit")]
	public class SpiritSO : UnityEngine.ScriptableObject, ISpiritData
	{
		[SerializeField] private string _spiritName;
		public string SpiritName => _spiritName;

		[SerializeField] private GameObject _iconPrefab64;
		public GameObject IconPrefab64 => _iconPrefab64;
	}

}