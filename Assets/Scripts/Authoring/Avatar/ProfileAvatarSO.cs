using ProjectB.Data.Static.Avatar;
using UnityEngine;

namespace ProjectB.Infrastructure.Authoring.Avatar
{

	[CreateAssetMenu(menuName = "Project B/Avatar/Profile Avatar")]
	public class ProfileAvatarSO : UnityEngine.ScriptableObject, IProfileAvatar
	{
		[SerializeField] private string _avatarId;
		public string AvatarId => _avatarId;
		
		[SerializeField] private GameObject _avatar256Prefab;
		public GameObject Avatar256Prefab => _avatar256Prefab;
	}

}