using System.Collections.Generic;

namespace ProjectB.Data.Static.Avatar
{

	public interface IAvatarDatabase
	{
		IReadOnlyList<IProfileAvatar> AvatarDatabaseList { get; }

		IProfileAvatar GetAvatarById(string avatarId);
	}

}