using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Views.Common
{

	public class IconView : UIView
	{
		[SerializeField] private Transform _iconParent;

		private GameObject _iconInstance;
		

		public void SetIcon(GameObject iconPrefab)
		{
			ClearIcon();

			if (iconPrefab != null)
			{
				var parent = _iconParent != null ? _iconParent : transform; // iconParent가 없으면 Transform 사용
				_iconInstance = Instantiate(iconPrefab, parent, false);
			}
		}

		public void ClearIcon()
		{
			if (_iconInstance != null)
			{
				Destroy(_iconInstance);
				_iconInstance = null;
			}
		}
	}

}
