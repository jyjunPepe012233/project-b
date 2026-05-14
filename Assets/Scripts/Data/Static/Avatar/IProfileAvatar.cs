using UnityEngine;

namespace ProjectB.Data.Static.Avatar
{

	public interface IProfileAvatar
	{
		string AvatarId { get; }
		
		GameObject Avatar256Prefab { get; }
	}

}