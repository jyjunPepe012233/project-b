namespace ProjectB.Data.Static.Player
{

	public interface IPlayerLevelUpSetting
	{
		int MaxLevel { get; }
		
		int GetLevelUpExpOfLevel(int level);
	}

}