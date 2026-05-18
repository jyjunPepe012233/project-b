using UnityEngine;

namespace MonoBehaviourValidator
{

	public interface IValidatable
	{
		MonoBehaviour GetMonoBehaviour();
		
		ValidationMethod GetValidationMethod();
	}

}