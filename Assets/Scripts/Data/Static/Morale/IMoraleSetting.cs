namespace ProjectB.Data.Static.Morale
{

	public interface IMoraleSetting
	{
		int MaxMorale { get; }
		
		int MoralePerRecharge { get; }

		int MaxDailyRechargeCount { get; }
	}

}
