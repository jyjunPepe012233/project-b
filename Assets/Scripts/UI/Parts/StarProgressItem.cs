using UnityEngine;

namespace ProjectB.UI.Parts
{

	public class StarProgressItem : MonoBehaviour
	{
		[SerializeField] private GameObject _enabled;
		[SerializeField] private GameObject _disabled;
		
		public void SetEnabled(bool enabled)
		{
			_enabled?.SetActive(enabled);
			_disabled?.SetActive(!enabled);
		}
	}

}