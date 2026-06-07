using ProjectB.Data.Static.Soldier;
using UnityEngine;

namespace ProjectB.Authoring.Soldier
{

	[CreateAssetMenu(menuName = "Project B/Soldier/Global Level Up Setting")]
	public class GlobalSoldierLevelUpSettingSO : UnityEngine.ScriptableObject, IGlobalSoldierLevelUpSetting
	{
		[SerializeField] private float _foodConsumeRatio = 0.3f;
		public float FoodConsumeRatio => _foodConsumeRatio;
	}

}