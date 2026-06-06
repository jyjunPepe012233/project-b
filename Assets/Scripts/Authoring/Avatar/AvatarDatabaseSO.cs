using System.Collections.Generic;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Avatar;
using UnityEngine;

namespace ProjectB.Infrastructure.Authoring.Avatar
{

	public class AvatarDatabaseSO : UnityEngine.ScriptableObject, IAvatarDatabase
	{
		[SerializeField] private InterfaceRefs<IProfileAvatar> _avatarDatabaseList;
		public IReadOnlyList<IProfileAvatar> AvatarDatabaseList => _avatarDatabaseList.Value;

		
		private static readonly Dictionary<string, IProfileAvatar> _cache = new();
		
		
		
		public IProfileAvatar GetAvatarById(string avatarId)
		{
			if (_cache.TryGetValue(avatarId, out var cachedAvatar))
			{
				return cachedAvatar;
			}
			
			foreach (var avatar in AvatarDatabaseList)
			{
				if (avatar.AvatarId == avatarId)
				{
					_cache[avatarId] = avatar;
					return avatar;
				}
			}

			Debug.LogError("Avatar가 존재하지 않습니다 AvatarId: " + avatarId);
			return null;
		}
	}

}