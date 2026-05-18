using InspectorGadgets.Attributes;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.Home
{
	public class HomeFullScreenOverlay : MonoBehaviour, IHomeFullScreenOverlay
	{
		[Required, SerializeField]
		private UIGroup _uiGroup;
	
		[Required, SerializeField]
		private string _overlayId;
		public string OverlayID => _overlayId;

		
	
		public void Open()
		{
			_uiGroup.Show();
		}

		public void Hide()
		{
			_uiGroup.Hide();
		}

		public void Show()
		{
			_uiGroup.Show();
		}

		public void Close()
		{
			_uiGroup.Hide();
		}
	}

}