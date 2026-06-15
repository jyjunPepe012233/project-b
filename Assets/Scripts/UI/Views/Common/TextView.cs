using AssetValidator;
using ProjectB.Core.Supports;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Views.Common
{

	public class TextView : UIView
	{
		[SerializeField] private TextMeshProUGUI _text;
		
		public void SetText(string text, bool forceRebuildLayout = false)
		{
			if (_text != null)
			{
				_text.text = text;
				_text.ForceMeshUpdate();
				
				LayoutRebuilder.ForceRebuildLayoutImmediate(_text.rectTransform.parent as RectTransform);
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