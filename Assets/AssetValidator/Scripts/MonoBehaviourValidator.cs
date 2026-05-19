using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace AssetValidator
{

	public static class MonoBehaviourValidator
	{
		public static string searchFolder = "Assets/Prefabs/";
		public const string logDir = "Assets/AssetValidator/Logs";

		
#if UNITY_EDITOR
		[MenuItem("Tools/Asset Validator/Validate All Prefabs")]
		public static ValidationLog ValidateAll()
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
							Debug.LogError($"Validation Error: {entry.name}\nPrefab: {path}\nGameObject: {hierarchyPath}\n");
						}
						
						ValidationResultEntry resultEntry = new ValidationResultEntry(isValid, entry.name, prefab, hierarchyPath);
						allResults.Add(resultEntry);
					}

					uniqueValidatables.Add(validatable);
				}
			}
			
			Debug.Log("Validation completed for all prefabs in folder: " + searchFolder);

			return SaveLog(allResults);
		}

		
		static ValidationLog SaveLog(List<ValidationResultEntry> results)
		{
			if (!AssetDatabase.IsValidFolder(logDir))
			{
				string parentDir = logDir.Substring(0, logDir.LastIndexOf('/'));
				string folderName = logDir.Substring(logDir.LastIndexOf('/') + 1);
				AssetDatabase.CreateFolder(parentDir, folderName);
			}

			string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
			string assetPath = $"{logDir}/ValidationLog_{timestamp}.asset";

			ValidationLog log = ScriptableObject.CreateInstance<ValidationLog>();
			log.validationResults = results.ToArray();

			AssetDatabase.CreateAsset(log, assetPath);
			AssetDatabase.SaveAssets();

			Debug.Log($"Validation log saved: {assetPath}", log);
			return log;
		}
#endif
	}

}