using System.Collections.Generic;
using UnityEngine;

namespace MonoBehaviourValidator
{

	[CreateAssetMenu(fileName = "ValidationLog", menuName = "MonoBehaviour Validator/Validation Log", order = 0)]
	public class ValidationLog : ScriptableObject
	{
		public ValidationResultEntry[] validationResults;
	}

}