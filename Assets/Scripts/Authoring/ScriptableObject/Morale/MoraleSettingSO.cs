using ProjectB.Data.Static.Morale;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Morale
{

	[CreateAssetMenu(menuName = "Project B/Morale/Morale Setting")]
	public class MoraleSettingSO : UnityEngine.ScriptableObject, IMoraleSetting
	{
		[SerializeField] private int _maxMorale = 999;
		public int MaxMorale => _maxMorale;
		
		[SerializeField] private int _moralePerRecharge = 100;
		public int MoralePerRecharge { get; }

		[SerializeField] private int _maxDailyRechargeCount = 10;
		public int MaxDailyRechargeCount => _maxDailyRechargeCount;
	}

}
