using UnityEngine;

namespace AssetValidator
{

	public interface IValidatable
	{
		MonoBehaviour GetMonoBehaviour();
		
		ValidationMethod GetValidationMethod();
	}

}