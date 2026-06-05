using ProjectB.Data.Static.Invasion;

namespace ProjectB.Gameplay.Inbound.Ports
{

	public interface ISweepService
	{ 
		void Sweep(IStageData targetStage, int count);
	}

}