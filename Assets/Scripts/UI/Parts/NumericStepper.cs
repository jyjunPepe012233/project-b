using System;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Parts
{

	public class NumericStepper : MonoBehaviour
	{
		[SerializeField] private InputField _inputField;
		[SerializeField] private Button _incrementButton;
		[SerializeField] private Button _decrementButton;
		
		[Header("Setting")]
		[SerializeField] private int _initialValue = 1;
		[SerializeField] private int _minValue = 0;
		[SerializeField] private int _maxValue = Int32.MaxValue;
		
		// 실제 런타임 값
		private int _value;

		public int Value => _value;
		public event Action ValueChanged;

		void Start()
		{
			SetValue(_initialValue);
		}

		void OnEnable()
		{
			_incrementButton.onClick.AddListener(OnIncrementClicked);
			_decrementButton.onClick.AddListener(OnDecrementClicked);
			
			_inputField.onEndEdit.AddListener(OnInputEndEdit);
		}

		void OnDisable()
		{
			_incrementButton.onClick.RemoveListener(OnIncrementClicked);
			_decrementButton.onClick.RemoveListener(OnDecrementClicked);
			
			_inputField.onEndEdit.RemoveListener(OnInputEndEdit);
		}

		void OnIncrementClicked()
		{
			if (_value < _maxValue)
				SetValue(_value + 1);
		}

		void OnDecrementClicked()
		{
			if (_value > _minValue)
				SetValue(_value - 1);
		}

		void OnInputEndEdit(string text)
		{
			if (int.TryParse(text, out int parsed))
			{
				SetValue(parsed);
			}
			else
			{
				// string to int 변환 실패 시 이전 값으로 복구 
				_inputField.text = _value.ToString();
			}
		}
		
		
		public void SetValue(int value)
		{
			_value = Mathf.Clamp(value, _minValue, _maxValue);
			_inputField.text = _value.ToString();
			ValueChanged?.Invoke();
		}

		public void SetMinValue(int minValue)
		{
			_minValue = minValue;
			if (_value < _minValue)
				SetValue(_minValue);
		}

		public void SetMaxValue(int maxValue)
		{
			_maxValue = maxValue;
			if (_value > _maxValue)
				SetValue(_maxValue);
		}
		
		public void SetIncrementButtonInteractable(bool interactable)
		{
			_incrementButton.interactable = interactable;
		}
		
		public void SetDecrementButtonInteractable(bool interactable)
		{
			_decrementButton.interactable = interactable;
		}
	}

}