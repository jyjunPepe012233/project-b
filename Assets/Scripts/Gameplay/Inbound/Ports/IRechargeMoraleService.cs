namespace ProjectB.Gameplay.Inbound.Ports
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