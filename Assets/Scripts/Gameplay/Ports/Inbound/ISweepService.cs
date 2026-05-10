using ProjectB.Data.Static.Invasion;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ISweepService
	{ 
		void Sweep(IStageData targetStage, int count);
	}

}