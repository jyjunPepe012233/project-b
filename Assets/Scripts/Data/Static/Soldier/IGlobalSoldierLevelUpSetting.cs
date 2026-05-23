namespace ProjectB.Data.Static.Soldier
{

	public interface IGlobalSoldierLevelUpSetting
	{
		// ConsumeFoods 한번에 소모할 식량의 양 비율. 기준은 사도의 레벨업에 필요한 식량의 양
		float FoodConsumeRatio { get; }
	}

}