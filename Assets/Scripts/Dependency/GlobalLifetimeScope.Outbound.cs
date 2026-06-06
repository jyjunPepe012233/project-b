using ProjectB.Data.Static.Item;
using ProjectB.Gameplay.Internal.Implements;
using ProjectB.Gameplay.Internal.Implements.Computer;
using ProjectB.Gameplay.Internal.Implements.Factory;
using ProjectB.Gameplay.Internal.Implements.Overlay;
using ProjectB.Gameplay.Internal.Implements.Screen;
using ProjectB.Gameplay.Internal.Ports;
using ProjectB.Gameplay.Internal.Ports.Computer;
using ProjectB.Gameplay.Internal.Ports.Factory;
using ProjectB.Gameplay.Internal.Ports.Overlay;
using ProjectB.Gameplay.Internal.Ports.Screen;
using ProjectB.Gameplay.Outbound.Ports.Error;
using ProjectB.Gameplay.Outbound.Ports.Player;
using ProjectB.Gameplay.Outbound.Ports.Scene;
using ProjectB.Infrastructure.Adapters.Error;
using ProjectB.Infrastructure.Adapters.Player;
using ProjectB.Infrastructure.Adapters.Scene;

namespace ProjectB.Dependency
{

	public partial class GlobalLifetimeScope
	{
		void RegisterOutboundSystems()
		{
			// Error
			RegisterPortAdapter<ICatchUncaughtErrorPort, CatchUncaughtErrorAdapter>();
			RegisterPortAdapter<IReportErrorPort, FirebaseReportErrorAdapter>();
			
			// Player
			RegisterPortAdapter<IHoldPlayerSessionPort, HoldPlayerSessionService>();
			RegisterPortAdapter<IInitializePlayerSessionPort, InitializePlayerSessionService>();
			RegisterPortAdapter<ILoadPlayerDataPort, TestLoadPlayerDataService>();
			
			// Scene
			RegisterPortAdapter<IControlScenePort, ControlSceneAdapter>();
		}
	}

}