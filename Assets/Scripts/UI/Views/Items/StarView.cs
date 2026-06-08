using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Views.Items
{

	public class StarView : UIView
	{
		[SerializeField] private GameObject _enabled;
		[SerializeField] private GameObject _disabled;
		
		public void SetStarActive(bool isActive)
		{
			_enabled?.SetActive(enabled);
			_disabled?.SetActive(!enabled);
		}
	}

}