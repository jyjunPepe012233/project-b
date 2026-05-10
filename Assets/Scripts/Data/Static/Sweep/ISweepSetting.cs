namespace ProjectB.Data.Static.Sweep
{

	public interface ISweepSetting
	{
		int MoraleCost { get; }
		
		float CoinRewardNoise { get; } // 0.1f면 10%. 계산 방식은 SweepService를 참고할 것
		
		float ItemRewardProbability { get; } // 0.1f면 10%. 계산 방식은 SweepService를 참고할 것
	}

}