using UnityEditor;
using UnityEngine;

namespace MonoBehaviourValidator
{
	[CustomEditor(typeof(ValidationLog))]
	public class ValidationLogEditor : Editor
	{
		private static readonly string[] TabNames = { "Errors", "Passed" };

		private int _selectedTab;
		private Vector2 _scrollPos;

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			SerializedProperty resultsProp = serializedObject.FindProperty("validationResults");

			_selectedTab = GUILayout.Toolbar(_selectedTab, TabNames);
			EditorGUILayout.Space(4);

			bool showErrors = _selectedTab == 0;

			int matchCount = 0;
			for (int i = 0; i < resultsProp.arraySize; i++)
			{
				SerializedProperty entry = resultsProp.GetArrayElementAtIndex(i);
				if (entry.FindPropertyRelative("isValid").boolValue != showErrors)
					matchCount++;
			}

			if (matchCount == 0)
			{
				string msg = showErrors ? "No errors found." : "No passed entries.";
				EditorGUILayout.HelpBox(msg, MessageType.Info);
				serializedObject.ApplyModifiedProperties();
				return;
			}

			_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.MaxHeight(500));

			for (int i = 0; i < resultsProp.arraySize; i++)
			{
				SerializedProperty entry = resultsProp.GetArrayElementAtIndex(i);
				bool entryIsValid = entry.FindPropertyRelative("isValid").boolValue;

				// Errors tab: show isValid==false / Passed tab: show isValid==true
				if (entryIsValid == showErrors) continue;

				EditorGUILayout.PropertyField(entry, GUIContent.none);
				EditorGUILayout.Space(4);
			}

			EditorGUILayout.EndScrollView();

			serializedObject.ApplyModifiedProperties();
		}
	}
}
