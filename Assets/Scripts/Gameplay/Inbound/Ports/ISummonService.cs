using System;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Inbound.Ports
{

	public interface ISummonService
	{
		void Summon(SummonType type);
	}

}