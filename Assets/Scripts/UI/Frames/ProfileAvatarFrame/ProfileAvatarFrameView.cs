using System;
using ProjectB.UI.Core;
using ProjectB.UI.Parts;
using UnityEngine;

namespace ProjectB.UI.Others.ProfileAvatarFrame
{
	
	[Serializable]
	public class ProfileAvatarFrameView : UIView
	{
		[SerializeField] private PrefabParent _avatarPrefabParent;

		public void SetAvatarPrefab(GameObject avatarPrefab)
		{
			_avatarPrefabParent.SetIcon(avatarPrefab);
		}
	}

}