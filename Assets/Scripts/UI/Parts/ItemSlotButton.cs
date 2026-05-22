using System;
using AssetValidator;
using InspectorGadgets.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Parts
{

	public class ItemSlotButton : ItemSlot, IValidatable
	{
		[Header("Button")]
		[Required, SerializeField] private Button _button;
		public Button Button => _button;
		
		public event Action Clicked;

		protected virtual void OnEnable()
		{
			_button.onClick.AddListener(OnButtonClicked);
		}

		protected virtual void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClicked);
		}

		void OnButtonClicked()
		{
			Clicked?.Invoke();
		}

		public MonoBehaviour GetMonoBehaviour() => this;

		public virtual ValidationMethod GetValidationMethod()
		{
			return new ValidationMethod()
				.Register("Button 할당", () => _button != null);
		}
	}

}