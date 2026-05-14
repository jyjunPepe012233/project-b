using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Parts
{

	public class SimpleIcon : MonoBehaviour
	{
		[SerializeField] private Image _iconImage;
		[SerializeField] private Image _iconBackground;
		[SerializeField] private bool _keepNativeSize;
		
		public void SetIcon(Sprite icon)
		{
			_iconImage.sprite = icon;
			
			if (_keepNativeSize)
			{
				_iconImage.SetNativeSize();
			}
		}
		
		public void SetBackgroundColor(Color color)
		{
			_iconBackground.color = color;
		}
	}

}