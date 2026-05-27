using System.Collections;
using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.UI.Services;
using UnityEngine;

namespace ProjectB.Infrastructure
{

	public class LoadSoldierDetailScreenService : BaseHomeOverlayScreenService, ILoadSoldierDetailScreenPort
	{
		protected override string OverlayID => "SoldierDetail";
	}

}