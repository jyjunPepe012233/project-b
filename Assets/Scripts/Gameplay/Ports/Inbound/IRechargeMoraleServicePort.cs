namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IRechargeMoraleServicePort
	{
		int GetRemainingRechargeCount();

		int GetExpectedMoraleAfterRecharge(int count);

		int GetRechargeCost(int count);
		
		bool VerifyRechargeCount(int count);
		
		void Recharge(int count);
	}

}