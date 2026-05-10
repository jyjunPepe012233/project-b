namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IRechargeMoraleServicePort
	{
		public bool VerifyRechargeCount(int count);
		
		void Recharge(int count);
	}

}