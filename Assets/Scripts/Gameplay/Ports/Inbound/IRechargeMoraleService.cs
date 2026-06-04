namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IRechargeMoraleService
	{
		int GetRemainingRechargeCount();

		int GetExpectedMoraleAfterRecharge(int count);

		int GetRechargeCost(int count);
		
		bool VerifyRechargeCount(int count);
		
		void Recharge(int count);
	}

}