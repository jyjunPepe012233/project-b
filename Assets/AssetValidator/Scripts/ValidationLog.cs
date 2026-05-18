using UnityEngine;

namespace AssetValidator
{

	[CreateAssetMenu(fileName = "ValidationLog", menuName = "MonoBehaviour Validator/Validation Log", order = 0)]
	public class ValidationLog : ScriptableObject
	{
		public ValidationResultEntry[] validationResults;
	}

}