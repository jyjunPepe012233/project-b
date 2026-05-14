namespace ProjectB.Data.Static.Morale
{

	public interface IMoraleSetting
	{
		int MaxMorale { get; }
		
		int MoralePerRecharge { get; }
		
		// 이번 프로젝트에서는 사기 충전 1회당 가격이 항상 같다고 가정.
		// 필요하면 충전 횟수에 따라 가격이 달라지게 할 수도 있음 (SoldierLevelUpCostSettingSO 참고)
		int RechargePrice { get; }

		int MaxDailyRechargeCount { get; }
	}

}
