using UnityEngine;

namespace ProjectB.Infrastructure.MonoSystems
{

	public class GameFrameSetup
	{
		public GameFrameSetup()
		{
			Initialize();
		}

		void Initialize()
		{
			QualitySettings.vSyncCount = 0; // 타겟 프레임타임을 지정하기 위해 VSync를 끔 
			Application.targetFrameRate = 60;
		}
		
	}

}