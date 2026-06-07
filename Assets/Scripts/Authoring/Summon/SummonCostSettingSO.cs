using ProjectB.Data.Static.Summon;
using UnityEngine;

namespace ProjectB.Authoring.Summon
{

	[CreateAssetMenu(menuName = "Project B/Summon/Summon Price Setting")]
	public class SummonCostSettingSO : UnityEngine.ScriptableObject, ISummonCostSetting
	{
		[SerializeField] private int _price1x;
		public int Price1x => _price1x;

		[SerializeField] private int _price10x;
		public int Price10x => _price10x;
	}

}