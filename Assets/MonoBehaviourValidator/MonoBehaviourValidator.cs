using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MonoBehaviourValidator
{

	public static class MonoBehaviourValidator
	{
		public static string searchFolder = "Assets/Prefabs/";

		
		[MenuItem("Tools/MonoBehaviour Validator/Validate All Prefabs")]
		public static void ValidateAll()
		{
			string[] guids = AssetDatabase.FindAssets(
				"t:Prefab",
				new[] { searchFolder }
			);
			
			Debug.Log("Found " + guids.Length + " prefabs in folder: " + searchFolder);
			
			
			List<IValidatable> preAllocatedValidatables = new List<IValidatable>();
			HashSet<IValidatable> uniqueValidatables = new HashSet<IValidatable>();
			List<ValidationResultEntry> allResults = new List<ValidationResultEntry>();
			
			foreach (var guid in guids)
			{
				preAllocatedValidatables.Clear();
				
				string path = AssetDatabase.GUIDToAssetPath(guid);
				GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
				prefab.GetComponentsInChildren<IValidatable>(true, preAllocatedValidatables);
				
				foreach (var validatable in preAllocatedValidatables)
				{
					ValidationMethod validationMethod = validatable.GetValidationMethod();
					
					if (uniqueValidatables.Contains(validatable))
					{
						continue;
					}

					string sourcePrefabPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(validatable.GetMonoBehaviour().gameObject);
					if (!sourcePrefabPath.Equals(path))
					{
						continue;
					}
					
					foreach (ValidationEntry entry in validationMethod.validationEntries)
					{
						string hierarchyPath = validatable.GetMonoBehaviour().transform.GetHierarchyPath();
						bool isValid = entry.validationFunc.Invoke();

						if (!isValid)
						{
							Debug.LogError($"Validation Error: {entry.message}\nPrefab: {path}\nGameObject: {hierarchyPath}\n");
						}
						
						ValidationResultEntry resultEntry = new ValidationResultEntry(isValid, entry.message, prefab, hierarchyPath);
						allResults.Add(resultEntry);
					}

					uniqueValidatables.Add(validatable);
				}
			}
			
			Debug.Log("Validation completed for all prefabs in folder: " + searchFolder);
		}

		
		
		static ulong CreateValidationTargetHash(string path, string hierarchyPath)
		{
			ulong hash = 14695981039346656037UL;
			foreach (char c in path + hierarchyPath)
			{
				hash ^= c;
				hash *= 1099511628211;
			}
			
			return hash;
		}
	}

}