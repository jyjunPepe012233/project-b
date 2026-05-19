using UnityEditor;
using UnityEngine;

namespace AssetValidator.Editor
{
	public class MonoBehaviourValidatorWindow : EditorWindow
	{
		private const string PREF_KEY_SEARCH_FOLDER = "MonoBehaviourValidator.SearchFolder";
		private const string DEFAULT_FOLDER = "Assets/Prefabs/";

		private string _searchFolder;
		private ValidationLog _log;
		private UnityEditor.Editor _logEditor;

		[MenuItem("Tools/MonoBehaviour Validator/Open Settings")]
		public static void Open()
		{
			var window = GetWindow<MonoBehaviourValidatorWindow>("MB Validator");
			window.minSize = new Vector2(360, 120);
			window.Show();
		}

		private void OnEnable()
		{
			_searchFolder = EditorPrefs.GetString(PREF_KEY_SEARCH_FOLDER, MonoBehaviourValidator.searchFolder);
			MonoBehaviourValidator.searchFolder = _searchFolder;
		}

		private void OnDisable()
		{
			DestroyLogEditor();
		}

		void OnDestroy()
		{
			DestroyLogEditor();
		}

		void OnGUI()
		{
			EditorGUILayout.Space(8); // 패딩

			// Log Directory (읽기 전용)
			EditorGUILayout.LabelField("Log Directory", EditorStyles.boldLabel);
			using (new EditorGUI.DisabledScope(true)) // using 내부의 필드들을 읽기 전용으로 만듬... 원리를 모르곘음 ㅠㅠ
			{
				EditorGUILayout.TextField(MonoBehaviourValidator.logDir);
			}
			EditorGUILayout.HelpBox("이 폴더에 Log 애셋이 생성됩니다", MessageType.Info);

			
			EditorGUILayout.Space(4); // Log Directory 섹션과 Search Folder 섹션 사이 간격

			// Search Folder 설정
			EditorGUILayout.LabelField("Search Folder", EditorStyles.boldLabel);
			EditorGUI.BeginChangeCheck();
			_searchFolder = EditorGUILayout.TextField(_searchFolder);
			if (EditorGUI.EndChangeCheck())
			{
				EditorPrefs.SetString(PREF_KEY_SEARCH_FOLDER, _searchFolder);
				MonoBehaviourValidator.searchFolder = _searchFolder;
			}
			EditorGUILayout.HelpBox("이 폴더 하위의 모든 프리팹이 검증됩니다.", MessageType.Info);
			

			EditorGUILayout.Space(4); // 위 섹션과 버튼 사이 간격

			using (new EditorGUI.DisabledScope(string.IsNullOrWhiteSpace(_searchFolder)))
			{
				if (GUILayout.Button("Validate All Prefabs"))
				{
					ValidationLog newLog = MonoBehaviourValidator.ValidateAll();
					if (newLog != null)
					{
						_log = newLog;
						RebuildLogEditor();
					}
				}
			}

			EditorGUILayout.Space(2); // 버튼 간 간격

			if (GUILayout.Button("Reset to Default"))
			{
				_searchFolder = DEFAULT_FOLDER;
				EditorPrefs.SetString(PREF_KEY_SEARCH_FOLDER, _searchFolder);
				MonoBehaviourValidator.searchFolder = _searchFolder;
			}

			EditorGUILayout.Space(4);
			EditorGUILayout.LabelField("Validation Log", EditorStyles.boldLabel);

			EditorGUI.BeginChangeCheck();
			_log = (ValidationLog)EditorGUILayout.ObjectField(_log, typeof(ValidationLog), false);
			if (EditorGUI.EndChangeCheck())
				RebuildLogEditor();

			if (_log != null && _logEditor != null)
			{
				EditorGUILayout.Space(4);
				_logEditor.OnInspectorGUI();
			}
		}

		void RebuildLogEditor()
		{
			DestroyLogEditor();
			if (_log != null)
				_logEditor = UnityEditor.Editor.CreateEditor(_log); // ValidationLog의 에디터를 생성 (ValidationLog의 인스펙터에는 검증 결과가 표시됨)
		}

		void DestroyLogEditor()
		{
			if (_logEditor != null)
			{
				DestroyImmediate(_logEditor);
				_logEditor = null;
			}
		}
	}
}
