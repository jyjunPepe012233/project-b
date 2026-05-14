using ProjectB.Data.Static.Invasion;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Invasion
{

	[CreateAssetMenu(menuName = "Project B/Sweep/Sweep Setting")]
	public class SweepSettingSO : UnityEngine.ScriptableObject, ISweepSetting
	{
		[SerializeField] private int _moraleCost;
		public int MoraleCost => _moraleCost;

		[SerializeField] private float _coinRewardNoise;
		public float CoinRewardNoise => _coinRewardNoise;

		[SerializeField] private float _itemRewardProbability;
		public float ItemRewardProbability => _itemRewardProbability;
	}

}
