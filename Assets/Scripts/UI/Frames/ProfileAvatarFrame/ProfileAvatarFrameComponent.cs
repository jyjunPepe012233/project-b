using ProjectB.Data.Static.Avatar;
using ProjectB.UI.Core;

namespace ProjectB.UI.Others.ProfileAvatarFrame
{

	public class ProfileAvatarFrameComponent : UIComponent<ProfileAvatarFrameView>
	{
		public void SetAvatar(IProfileAvatar profileAvatar)
		{
			view.SetAvatarPrefab(profileAvatar.Avatar256Prefab);
		}
	}

}