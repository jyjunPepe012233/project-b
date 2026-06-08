using ProjectB.Core.Supports;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Views.Buttons
{

	public class IconTextButtonView : ButtonView
	{
		[SerializeField] private Image _iconImage;
		[SerializeField] private TextMeshProUGUI _text;
		
		public void Initialize(Sprite iconSprite, string text)
		{
			SetIcon(iconSprite);
			SetText(text);
		}
		
		public void SetIcon(Sprite iconSprite)
		{
			if (_iconImage != null)
			{
				_iconImage.sprite = iconSprite;
			}
		}
		
		public void SetText(string text)
		{
			if (_text != null)
			{
				_text.text = text;
			}
		}
	}

}