using AssetValidator;
using ProjectB.Core.Supports;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Views.Common
{

	public class TextView : UIView
	{
		[SerializeField] private TextMeshProUGUI _text;
		
		public void SetText(string text)
		{
			if (_text != null)
			{
				_text.text = text;
			}
			else
			{
				Debug.LogError($"TextLabelView: Text가 설정되지 않음. 위치: {TransformDebug.GetHierarchyPath(transform)}");
			}
		}

		public override ValidationMethod GetValidationMethod()
		{
			return base.GetValidationMethod()
				.Register("Text 할당", () => _text != null);
		}
	}

}